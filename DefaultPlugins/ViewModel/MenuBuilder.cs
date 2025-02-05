
using Model;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using DefaultPlugins;
using Shared;
using System.Windows.Controls;
using Extensions.Util;
using System;
using System.Reflection;

namespace ViewModel
{
    public class MenuBuilder
    {
        public  Menu StandardMenu= new Menu();
        public static List<CustomMenu> CustomMainMenu = BuildAndLoadMenu();
        public static MenuItem SaveMenu =new MenuItem();
        public static MenuItem SaveAsMenu = new MenuItem();
        public static MenuItem NewMenu = new MenuItem();
        public static MenuItem OpenMenu=new MenuItem();
        public static MenuItem HexViewMenu=new MenuItem();
        public static List<MenuItem> ItemsForSelectedText = new List<MenuItem>();
        private static IEnumerable<INamedActionPlugin>? plugins;

        private static void SaveMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public MenuBuilder(Menu menu)
        {
             StandardMenu= menu;
        }
        public  static List<CustomMenu> BuildAndLoadMenu()
        {
                 plugins = AllPlugins.InvokePlugins(PluginManager.GetPluginsLocal());
            var menu = GetMenuHeaders(plugins);

                foreach (var item in menu)
                {
                    item.MenuItems.AddRange(GetMenuItemsForHeader(item.Header, plugins));
                  //  if (item.Header == "View") item.MenuItems.AddRange(viewAsModel.Load());
                  }
//                viewAsModel.loadFileTypes();
                
                return menu;

        }
        
         

        public static  List<CustomMenu> GetMenuHeaders(IEnumerable<INamedActionPlugin> plugins)
        {

            var result = plugins.Where(p => p.Configuration.ShowInMenu.HasContent() && p.Configuration.ShowInMenuItem.HasContent())
                .Select(p => p.Configuration.ShowInMenu).Distinct()
            .Select(p => new CustomMenu { Header = p }).ToList();
   
            return result;
        }
 



         
        public  static List<CustomMenuItem> GetMenuItemsForHeader(string header, IEnumerable<INamedActionPlugin> plugins)
        {
            var result = new List<CustomMenuItem>();
            //we do special handling on plugin menu 
            if (header.Equals("plugins", StringComparison.OrdinalIgnoreCase) == false)
            {
                var withMenu = plugins.Where(p => p.Configuration.ShowInMenu.HasContent() && p.Configuration.ShowInMenuItem.HasContent()).ToList();
                var myItems = withMenu.Where(p => p.Configuration.ShowInMenu == header).ToList();
                result = myItems
                    .Select(p => new CustomMenuItem { Title = $"{p.Configuration.ShowInMenuItem} ({p.Configuration.KeyCommand})", Plugin = p })
                    .ToList();
            }
            return result;
        }

        public List<MenuItem> GetItemsForSelectedText()
        {
            List < MenuItem > result = new List < MenuItem >();
            if (plugins!= null)
               result = plugins.Where(p=>p.ParameterIsSelectedText)
                    .Select(p => new MenuItem { Header = (p.Configuration.ShowInMenuItem) })
                    .ToList();

            return result;
        }

        public void AdaptToStandardMenu()
        {

            if (StandardMenu == null) throw new ArgumentNullException();
            //            StandardMenu.Items.Clear(); 
           var  index = WPFUtil.IndexOfText(StandardMenu.Items, "File");
            if (index.HasValue==false )
               index = StandardMenu.Items.Add(new MenuItem { Header = "File" });

            var existingItem = StandardMenu.Items[index.Value] as MenuItem;
            if (existingItem != null)
            {
                NewMenu = GetNewMenu();
               OpenMenu = GetOpenMenu();
                HexViewMenu = GetHexViewMenu();

                SaveMenu = GetSaveMenu();
                SaveAsMenu = GetSaveAsMenu();
         
                existingItem.Items.Add(NewMenu);

                existingItem.Items.Add(OpenMenu);

                existingItem.Items.Add(HexViewMenu);

                existingItem.Items.Add(SaveMenu);

                existingItem.Items.Add(SaveAsMenu);






                foreach (var item in CustomMainMenu)
                {
                    index = null;
                    if (StandardMenu != null)
                        index = WPFUtil.IndexOfText(StandardMenu.Items, item.Header);

                    int intindex = int.MinValue;
                    if (index == null && StandardMenu != null)
                    {
                        index = StandardMenu.Items.Add(new MenuItem { Header = item.Header });
                        intindex = index.Value;
                    }
                    else if (index.HasValue)
                        intindex = index.Value;

                    if (StandardMenu != null && item.Header.Equals("plugins", StringComparison.OrdinalIgnoreCase))
                    {
                        //                    if(intindex==-1) index = StandardMenu.Items.Add(new MenuItem { Header = "Plugins" });


                        ItemsForSelectedText = GetItemsForSelectedText();
                        foreach (var itemWithSelected in ItemsForSelectedText)
                        {
                            existingItem = StandardMenu.Items[intindex] as MenuItem;
                            if (existingItem != null) existingItem.Items.Add(itemWithSelected);
                        }

                    }
                    if (StandardMenu != null && item.Header.Equals("plugins", StringComparison.OrdinalIgnoreCase))

                        foreach (var menuItem in item.MenuItems)
                        {
                            MenuItem? newExistMenuItem = StandardMenu != null && intindex <= StandardMenu.Items.Count && StandardMenu.Items[intindex] is MenuItem ? StandardMenu.Items[intindex] as MenuItem : new MenuItem();
                            var newItem = new MenuItem { Header = menuItem.Title };
                            var itemToCheck = newExistMenuItem != null ? newExistMenuItem : newItem;
                            if (newExistMenuItem! != null) newExistMenuItem.Items.Add(newItem);
                            /*
                            var hexViewTest = GetHexViewMenu(newItem);
                            if (hexViewTest != null) HexViewMenu = hexViewTest;

                            var saveAsTest = GetSaveAsMenu(newItem);
                            if (saveAsTest != null) SaveAsMenu = saveAsTest;
                            var saveTest = GetSaveMenu(newItem);
                            if (saveTest != null)
                            {
                                SaveMenu = saveTest;
                            }
                            var openTest = GetOpenMenu(newItem);
                            if (openTest != null)
                                OpenMenu = openTest;
                            */
                        }


                }





            }

        }

        public MenuItem GetSaveMenu()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.FileSave);
            var result = new MenuItem { Header = $"{plugin.Configuration.ShowInMenuItem} ({plugin.Configuration.KeyCommand})" };
            return result;

        }


        public MenuItem GetSaveAsMenu()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.FileSaveAs);
            var result = new MenuItem { Header = $"{plugin.Configuration.ShowInMenuItem} ({plugin.Configuration.KeyCommand})" };
            return result;
        }





        public MenuItem GetNewMenu()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.FileNew);
            var result = new MenuItem { Header = $"{plugin.Configuration.ShowInMenuItem} ({plugin.Configuration.KeyCommand})" };
                 return result;

        }



        public MenuItem GetHexViewMenu()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.Hex);
            var result = new MenuItem { Header = $"{plugin.Configuration.ShowInMenuItem} ({plugin.Configuration.KeyCommand})" };
            return result;
        }


        public MenuItem GetOpenMenu()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.FileOpen);
            var result = new MenuItem { Header = $"{plugin.Configuration.ShowInMenuItem} ({plugin.Configuration.KeyCommand})" };
            return result;

        }





    }

}

