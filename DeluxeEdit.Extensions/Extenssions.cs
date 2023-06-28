using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace DeluxeEdit.Extensions
{
    public static class Extenssions
    {
        public static int IndexOf(this string buffer, char c)
        { 
            int indexOf = -1;
            for (int i = 0; i < buffer.Length;i++)
            {
                if (buffer[i] ==  c)
                {
                    indexOf = i;
                    break;
                }
            }
            return indexOf;
       }
        public static IEnumerable<string> ReadLinesMax(this StreamReader reader, int maxLines)
        {
            var result = new List<string>();
            int i = 0;
            string line = String.Empty;


            while ((line=reader.ReadLine()) != null && i<maxLines ) 
            {
                //were we manualy have to locate the NUL char 
                int index = line.IndexOf('\0');
                var resultLine = new String( line.ToCharArray(), 0, index);
                result.Add(resultLine);
                i++;
            }
            return result;
        }
        
        public static bool IsEmpty(this string? item)
        {
            return String.IsNullOrEmpty(item);
        }
        public static bool HasContent(this string? item)
        {
            return !String.IsNullOrEmpty(item);
        }
        public static int ToInt(this string item)
        {
            return int.Parse(item);
        }
        public static long ToLong(this string item)
        {
            return long.Parse(item);
        }

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }


    }
}
