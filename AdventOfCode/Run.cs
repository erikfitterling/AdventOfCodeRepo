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
        public Run( StartUp start) 
        {
            startUp = start;
            
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
                            su.X = startUp.map.GetLength(1) - 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.X--;
                            CheckPositionNew(su);
                        }
                        break;
                    case Direction.Right:
                        if (su.X == startUp.map.GetLength(1) -1)
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
                            su.Y = startUp.y - 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.Y--;
                            CheckPositionNew(su);
                        }
                        break;
                    case Direction.Down:
                        if (su.Y == startUp.y - 1)
                        {
                            su.Y = 1;
                            CheckPositionNew(su);
                        }
                        else
                        {
                            su.Y = startUp.y - 1;
                            CheckPositionNew(su);
                        }
                        break;
                }

                
            }
            startUp.Print();
        }

        public void CheckPosition(Blizzard su)
        {
            if (Char.IsDigit(startUp.map[su.Y, su.X]))
            {
                if (startUp.map[su.Y, su.X] == '2')
                {
                    startUp.map[su.Y, su.X] = su.Sign;
                }
                else
                {
                    startUp.map[su.Y, su.X]--;
                }
            }
            else
            {
                startUp.map[su.Y, su.X] = '.';
            }
        }

        public void CheckPositionNew(Blizzard su)
        {
            if (Char.IsDigit(startUp.map[su.Y, su.X]))
            {
                startUp.map[su.Y, su.X]++;
            }
            else if(startUp.map[su.Y, su.X] == '.')
            {
                startUp.map[su.Y, su.X] = su.Sign;
            }
            else
            {
                startUp.map[su.Y, su.X] = '2';
            }
        }


    }
}
