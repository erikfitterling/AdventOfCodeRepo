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
        public int MLength { get; set; }
        public int MHeight { get; set; }
        public string Line { get; set; }

        public Map(int height, int length, string line) 
        {
            MLength= length;
            MHeight= height;
            Line= line;
            map = new char[height, length];
        }
    }
}
