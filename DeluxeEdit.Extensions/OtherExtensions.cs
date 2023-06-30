using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeluxeEdit.Extensions
{
    public static class OtherExtensions
    {
        public static IEnumerable<string> ReadLinesMax(this StreamReader reader, int maxLines)
        {
            var result = new List<string>();
            int i = 0;
            string line = String.Empty;


            while ((line = reader.ReadLine()) != null && i < maxLines)
            {
                //were we manualy have to locate the NUL char 
                int index = line.IndexOf('\0');
                var resultLine = new String(line.ToCharArray(), 0, index);
                result.Add(resultLine);
                i++;
            }
            return result;
        }


    }
}
