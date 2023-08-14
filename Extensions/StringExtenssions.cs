using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class StringExtenssions
    {
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
        public static int? IndexOfDigit(this string item, int pos = 0)
        {
            int? result = null;
            var input = item.Substring(pos);
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int? LastIndexOfDigit(this string item, int pos = 0)
        {
            int? result = null;
            var input = item.Substring(pos);
             for (int i = input.Length-1; i > 0 ; i--)
            {
                if (Char.IsDigit(input[i]))
               {
                    result = i;
                    break;
                }
            }
            return result;
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
