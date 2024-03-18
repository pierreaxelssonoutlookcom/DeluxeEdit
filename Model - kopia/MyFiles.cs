using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MyFiles
    {
        public static MyFile Current { get; set; }

        public static List<MyFile> Files { get; set; } = new List<MyFile>();

    }
}
