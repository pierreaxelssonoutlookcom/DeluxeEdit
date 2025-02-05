
using Model;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using DefaultPlugins;
using Shared;
using System.Windows.Controls;
using Extensions.Util;
using DefaultPlugins.ViewModel.MainActions;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ViewModel
{
    public class MenuBuilder
    {
        public  Menu StandardMenu= new Menu();
        public static List<CustomMenu> CustomMainMenu = BuildAndLoadMenu();
        public static MenuItem? SaveMenu;
        public static MenuItem? SaveAsMenu;
        public static MenuItem? NewMenu;
        public static MenuItem? OpenMenu;
        public static MenuItem? HexViewMenu;
        public static List<MenuItem> ItemsForSelectedText = new List<MenuItem>(); 
        private static List<INamedActionPlugin>? pluginsWithSelelected=null;

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
                var plugins = AllPlugins.InvokePlugins(PluginManager.GetPluginsLocal());
            pluginsWithSelelected = plugins.Where(p=>p.ParameterIsSelectedText).ToList();
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
            var withMenu = plugins.Where(p => p.Configuration.ShowInMenu.HasContent() && p.Configuration.ShowInMenuItem.HasContent()).ToList();
            var myItems = withMenu.Where(p => p.Configuration.ShowInMenu == header).ToList();
            var result = myItems
                .Select(p => new CustomMenuItem { Title = $"{p.Configuration.ShowInMenuItem} ({p.Configuration.KeyCommand})", Plugin = p })
                .ToList();

            return result;
        }

        public List<MenuItem> GetItemsForSelectedText()
        {
            List < MenuItem > result = new List < MenuItem >();
            if (pluginsWithSelelected != null)
                result = pluginsWithSelelected.Select(p =>
                new MenuItem { Header = (p.Configuration.ShowInMenuItem) }).ToList();

            return result;
        }

        public void AdaptToStandardMenu()
        {

            if (StandardMenu == null) throw new ArgumentNullException();
//            StandardMenu.Items.Clear(); 
            foreach (var item in CustomMainMenu)
            {
                int? index = null;
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
                    ItemsForSelectedText = GetItemsForSelectedText();
                    foreach (var itemWithSelected in ItemsForSelectedText)
                        StandardMenu.Items.Add(itemWithSelected);

                    
                }
                foreach (var menuItem in item.MenuItems)
                {
                    MenuItem? newExistMenuItem = StandardMenu != null && intindex <= StandardMenu.Items.Count && StandardMenu.Items[intindex] is MenuItem ? StandardMenu.Items[intindex] as MenuItem : new MenuItem();
                    var newItem = new MenuItem { Header = menuItem.Title };
                    var itemToCheck=newExistMenuItem!=null ? newExistMenuItem : newItem;
                    if (newExistMenuItem! != null) newExistMenuItem.Items.Add(newItem);
                    var newTest = GetNewMenu(newItem);
                    if (newTest != null) NewMenu = newTest;
                    var hexViewTest  = GetHexViewMenu(newItem);
                    if (hexViewTest != null) HexViewMenu= hexViewTest;
            
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
                }


            }







        }

        public MenuItem? GetSaveMenu(MenuItem menuItem)
        {
            return WPFUtil.GetMenuItemForStartText(menuItem, "Save (");
        }


        public MenuItem? GetSaveAsMenu(MenuItem menuItem)
        {
            return WPFUtil.GetMenuItemForStartText(menuItem, "Save As");

        }





        public MenuItem? GetNewMenu(MenuItem menuItem)
        {
            return WPFUtil.GetMenuItemForStartText(menuItem, "New");

        }



        public MenuItem? GetHexViewMenu(MenuItem menuItem)
        {
            return WPFUtil.GetMenuItemForStartText(menuItem, "Hex View");
        }


        public MenuItem? GetOpenMenu(MenuItem menuItem)
        {
            return WPFUtil.GetMenuItemForStartText(menuItem, "Open");

        }





    }

}

