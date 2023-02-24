using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Blizzard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public char Sign { get; set; }
        public Blizzard(int x, int y, Direction direction, char sign) 
        {
            X= x;
            Y= y;
            Direction = direction;
            Sign = sign;
        }
    }
}
