
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

namespace ViewModel
{
    public class MenuBuilder
    {
            public MenuBuilder( )
        {


        }
        public static List<CustomMenu> MainMenu = BuildAndLoadMenu();

        public  static List<CustomMenu> BuildAndLoadMenu()
        {
                var plugins = AllPlugins.InvokePlugins(PluginManager.GetPluginsLocal());
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
            var test = myItems.Select(p => p.Configuration.ShowInMenuItem).ToList();
            var result = myItems
                .Select(p => new CustomMenuItem { Title = $"{p.Configuration.ShowInMenuItem} ({p.Configuration.KeyCommand})", Plugin = p })
                .ToList();

            return result;
        }
        


        public void ShowMenu(Menu mainMenu)
        {

            if (mainMenu == null) throw new ArgumentNullException();

            foreach (var item in MainMenu)
            {
                int? index = null;
                if (mainMenu != null)
                    index = WPFUtil.IndexOfText(mainMenu.Items, item.Header);

                int intindex = int.MinValue;
                if (index == null && mainMenu != null)
                {
                    index = mainMenu.Items.Add(new MenuItem { Header = item.Header });
                    intindex = index.Value;
                }
                else if (index.HasValue)
                    intindex = index.Value;



                foreach (var menuItem in item.MenuItems)
                {
                    MenuItem? newExistMenuItem = mainMenu != null && intindex <= mainMenu.Items.Count && mainMenu.Items[intindex] is MenuItem ? mainMenu.Items[intindex] as MenuItem : new MenuItem();
                    var newItem = new MenuItem { Header = menuItem.Title };
                    if (newExistMenuItem! != null) newExistMenuItem.Items.Add(newItem);

                }

            }







        }









    }

}

