using DeluxeEdit.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace DeluxeEdit.DefaultActions.Actions
{
    public class UrlDecodeAction : INamedAction
    {
        public string Name { get; set; } ="UrlDeclode";
        public string Titel { get; set; } = "Url Declode";
        public List<Char> ShortCutCommand { get; set; }
        public string Parameter { get; set; }
        public string Result { get; set; }

        public Func<string, string> Action { get; set; }

 


        public string Perform(string parameter)
        {
            var result = WebUtility.UrlDecode(parameter);
            return result;
        }

    }


}
