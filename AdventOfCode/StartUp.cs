using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class StartUp
    {
        public Blizzard[] blizzards;
        public Map map;
        public string line;


        public StartUp()
        {
            CreateMap();
            PrintMap();
        }

        public void CreateMap()
        {
            StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Map.txt"));
            int counter = 0;
            int y = 0;

            while(!sr.EndOfStream) 
            {
                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '#' && line[i] != '.')
                    {
                        counter++;
                    }
                }
                y++;
            }

            map = new Map(y, line.Length, line);
            blizzards = new Blizzard[counter];
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            counter = 0;
            y = 0;

            while (!sr.EndOfStream)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case '<':
                            blizzards[counter] = new Blizzard(x, y, Direction.Left, '<');
                            counter++;
                            map.map[y, x] = '<';
                            break;
                        case '>':
                            blizzards[counter] = new Blizzard(x, y, Direction.Left, '>');
                            counter++;
                            map.map[y, x] = '>';
                            break;
                        case 'v':
                            blizzards[counter] = new Blizzard(x, y, Direction.Left, 'v');
                            counter++;
                            map.map[y, x] = 'v';
                            break;
                        case '^':
                            blizzards[counter] = new Blizzard(x, y, Direction.Left, '^');
                            counter++;
                            map.map[y, x] = '^';
                            break;
                        case '#':
                            map.map[y, x] = '#';
                            break;
                        case '.':
                            map.map[y, x] = '.';
                            break;
                    }
                }
                y++;
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < map.MHeight; i++)
            {
                for (int j = 0; j < map.MLength; j++)
                {
                    Console.Write(map.map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
