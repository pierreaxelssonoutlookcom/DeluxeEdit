using Extensions.Model;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Extensions
{
    public static class OtherExtensions
    {

        public static PluginFile ParseNugetFileName(this string path)
        {
            var result = new PluginFile();
            result.LocalPath = path;

            var index = StringExtenssions.IndexOfDigit(path);
            var lastIndex = StringExtenssions.LastIndexOfDigit(path);
            result.Name = Path.GetFileNameWithoutExtension(new FileInfo(path).Name);
            if (index.HasValue && lastIndex.HasValue)
            {
                result.Version = Version.Parse(StringExtenssions.SubstringPos(path, index.Value, lastIndex.Value));
                result.Name= Path.GetFileNameWithoutExtension(StringExtenssions.SubstringPos(path, 0, index.Value-2));
            };                                                                                                         

            return result;
        }
        /// <summary>
        /// Also returns bytes writtten
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="maxLines"></param>
        /// <returns></returns>
        public async static Task<List<string>> ReadLinesMax(this StreamReader reader, int maxLines)
        {

            var result = new List<string>();
            for (int i = 0; i < maxLines; i++)
            {
                string line = await reader.ReadLineAsync();
                if (line != null)
                {
                    int index = line.IndexOf('\0');
                    var resultLine = new String(line.ToCharArray(), 0, index);
                    result.Add(resultLine);
                }

            }
            return result;
        }
        /// <summary>
        /// Returns bytes written, removes lines written
        /// </summaryR
        /// S<param name="writer"></param>
        /// <param name="buffer"></param>
        /// <param name="maxLines"></param>
        /// <returns></returns>
        public static async  Task<bool> WriteLinesMax(this StreamWriter writer, List<string> buffer, int maxLines)
        {

            var result = false;
            foreach (var item in buffer.Take(maxLines).Select(p=>p.ToString()))
            {
                await writer.WriteLineAsync(item);
                result = true;

            }


            return result ;
            

        }


    }
}
