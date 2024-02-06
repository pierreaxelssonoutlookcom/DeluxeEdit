
using Model.Interface;
using System;
using System.Collections.Generic;

namespace Model
{

    public class CustomMenuItem

    {
        public string Title { get; set; }
        public INamedActionPlugin Plugin { get; set; }
        public ActionParameter Parameter { get; set; }

    }
}