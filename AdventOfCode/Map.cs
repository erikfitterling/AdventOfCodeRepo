using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Map
    {
        public char[,] map { get; set; }
        public int MLength;
        public int MHeight;

        public Map(char[,] mmap, int height) 
        {
            map= mmap;
            MLength= mmap.Length;
            MHeight= height;
        }
    }
}
