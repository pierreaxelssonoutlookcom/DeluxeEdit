
using System;
using System.Collections.Generic;

namespace Model
{
    public class CustomMenu
    {
        public string Header { get; set; }
        public List<CustomMenuItem> MenuItems { get; set; }


    }

    public class CustomMenuItem

    {
        public string Title { get; set; }
    public Action OnAction { get; set; }
q    }
}
