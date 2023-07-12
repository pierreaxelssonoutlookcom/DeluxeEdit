using Extensions.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class OtherExtensions
    {
        /// <summary>
        /// Also returns bytes writtten
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="maxLines"></param>
        /// <returns></returns>
        public static ListBytes ReadLinesMax(this StreamReader reader, int maxLines)
        {
            long oldPos = reader.BaseStream.Position;

            var result = new ListBytes();
            int i = 0;
            string line = String.Empty;


            while ((line = reader.ReadLine()) != null && i < maxLines)
            {
                //were we manualy have to locate the NUL char 
                int index = line.IndexOf('\0');
                var resultLine = new String(line.ToCharArray(), 0, index);
                result.Items.Add(resultLine);
                i++;
            }
            result.Bytes=reader.BaseStream.Position - oldPos;
            return result;
        }

        /// <summary>
        /// Returns bytes written, removes lines written
        /// </summaryR
        /// S<param name="writer"></param>
        /// <param name="buffer"></param>
        /// <param name="maxLines"></param>
        /// <returns></returns>
        public static long WriteLinesMax(this StreamWriter writer, List<string> buffer, int maxLines)
        {
            long oldPos=writer.BaseStream.Position;
            var removals = new List<string>();

            foreach (var item in buffer.Take(maxLines).Select(p=>p.ToString()))
            {
                writer.WriteLine(item);
                removals.Add(item);
            }


            removals.Select(p => buffer.Remove(p));

            return writer.BaseStream.Position - oldPos;
            

        }


    }
}
