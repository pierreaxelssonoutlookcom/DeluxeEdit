using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ActionParameter
    {
        public string Parameter { get; set; } = "";
        public ActionParameter()
        {
            Parameter = "";
        }
        public ActionParameter(string value)
        {
            Parameter = value;
        }
    }
}
