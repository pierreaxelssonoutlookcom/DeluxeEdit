using System.Collections.Generic;

namespace Model
 {
    public class ActionParameter
    {
        public string Parameter { get; set; } = "";
        public List<string> InData { get; set; }
        public ActionParameter()
        {
            Parameter = "";
            InData = new List<string>();
        }
        public ActionParameter(string parameter, List<string> indata)
        {
            Parameter = parameter;
            InData = indata;
        }
        public ActionParameter(string parameter)
        {
            Parameter = parameter;       }
    }
}
