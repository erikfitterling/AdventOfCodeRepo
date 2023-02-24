using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Run
    {
        private StartUp startUp;
        private Map map;
        public Run( StartUp start, Map mmap) 
        {
            startUp = start;
            map = mmap;
            
        }
        public void Update()
        {
            for (int i = 0; i < startUp.blizzards.Length; i++)
            {
                Blizzard su = startUp.blizzards[i];
                CheckPosition(su);
                
                    
                switch (su.Direction)
                {
                    //Falls Fehler statt -1 -2
                    case Direction.Left:
                        if (su.X == 1)
                        {
                            su.X = map.map.GetLength(1) - 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.X--;
                            CheckPositionNew(su);
                        }
                        break;
                    case Direction.Right:
                        if (su.X == map.map.GetLength(1) -1)
                        {
                            su.X = 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.X++;
                            CheckPositionNew(su);

                        }
                        break;
                    case Direction.Up:
                        if (su.Y == 1)
                        {
                            su.Y = map.MHeight - 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.Y--;
                            CheckPositionNew(su);
                        }
                        break;
                    case Direction.Down:
                        if (su.Y == map.MHeight - 1)
                        {
                            su.Y = 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.Y = map.MHeight - 1;
                            CheckPositionNew(su);
                        }
                        break;
                }

                
            }
            startUp.PrintMap();
        }

        public void CheckPosition(Blizzard su)
        {
            if (Char.IsDigit(map.map[su.Y, su.X]))
            {
                if (map.map[su.Y, su.X] == '2')
                {
                    map.map[su.Y, su.X] = su.Sign;
                }
                else
                {
                    map.map[su.Y, su.X]--;
                }
            }
            else
            {
                map.map[su.Y, su.X] = '.';
            }
        }

        public void CheckPositionNew(Blizzard su)
        {
            if (Char.IsDigit(map.map[su.Y, su.X]))
            {
                map.map[su.Y, su.X]++;
            }
            else if(map.map[su.Y, su.X] == '.')
            {
                map.map[su.Y, su.X] = su.Sign;
            }
            else
            {
                map.map[su.Y, su.X] = '2';
            }
        }


    }
}
