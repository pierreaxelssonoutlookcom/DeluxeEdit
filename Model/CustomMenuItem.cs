
using Model.Interface;
using System;
using System.Collections.Generic;

namespace Model
{

    public class CustomMenuItem

    {
        public string Title { get; set; }
        public string Plugin { get; set; }

        public Func<ActionParameter,string>  MenuAction { get; set; }



    }
}    