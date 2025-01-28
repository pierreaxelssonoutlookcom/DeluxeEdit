
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
        public static MenuItem SaveMenu=new MenuItem() ;
        public static MenuItem SaveAsMenu = new MenuItem();
        public MenuBuilder(Menu menu)
        {
             StandardMenu= menu;
        }
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



                foreach (var menuItem in item.MenuItems)
                {
                    MenuItem? newExistMenuItem = StandardMenu != null && intindex <= StandardMenu.Items.Count && StandardMenu.Items[intindex] is MenuItem ? StandardMenu.Items[intindex] as MenuItem : new MenuItem();
                    var newItem = new MenuItem { Header = menuItem.Title };
                    var itemToCheck=newExistMenuItem!=null ? newExistMenuItem : newItem;
                    if (newExistMenuItem! != null) newExistMenuItem.Items.Add(newItem);
                    var saveAsTest = GetSaveAsMenu(newItem);
                    if (saveAsTest != null) SaveAsMenu = saveAsTest;
                    var saveTest = GetSaveMenu(newItem);
                    if (saveTest != null) SaveMenu = saveTest;

                }


            }







        }
        public MenuItem? GetSaveMenu(MenuItem menuItem)
        {
            MenuItem? result = null;
            string? headerString = null;
            object? header = null;
            if (menuItem != null) header = menuItem.Header;

            if (header != null) headerString = header.ToString();
            if (menuItem != null && headerString != null && headerString.StartsWith("Save") && headerString.StartsWith("Save As") == false)
                result = menuItem;

            return result;
        }
        public MenuItem? GetSaveAsMenu(MenuItem menuItem)
        {
            MenuItem? result = null;
            string? headerString = null;
            object? header = null;
            if (menuItem != null) header = menuItem.Header;

            if (header != null) headerString = header.ToString();
            if (menuItem != null && headerString != null && headerString.StartsWith("Save As"))
                result = menuItem;

            return result;
   
        }





    }

}

