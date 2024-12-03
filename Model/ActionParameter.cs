using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ActionParameter
    {
        public string Parameter { get; set; } = "";
        public Encoding? Encoding { get; set; }

        public List<string> InData { get; set; }
        
        public ActionParameter()
        {
            Parameter = "";
            InData = new List<string>();
        }
        public ActionParameter(string parameter) : this()
        {
            if 
                (parameter != null) Parameter = parameter;
        }
        public ActionParameter(string parameter, Encoding? encoding=null) : this()
        {
            if (parameter != null) Parameter = parameter;
            Encoding = encoding;
        }
        public ActionParameter(string parameter, string indata, Encoding? encoding=null) : this()
        {
            Parameter = parameter;
            InData = indata.Split(Environment.NewLine).ToList(); 
            Encoding = encoding;
         }

        public ActionParameter(string parameter, List<string> indata, Encoding? encoding=null): this()
        {
            Parameter = parameter;
            InData = indata;
            Encoding = encoding;    
        }

    }
}
