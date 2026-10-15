using System;
using System.Collections.Generic;
using System.Text;

namespace igra
{
    class ConsoleRender
    {
        public void Draw(string[] lines, Player player, List<GameObject> objects)
        {
            int radius = player.View;

            for (int y = player.Y - radius; y <= player.Y + radius; y++)
            {
                for (int x = player.X - radius; x <= player.X + radius; x++)
                {
                    char symbol = '.';

                    if (y < 0 || y >= lines.Length || x < 0 || x >= lines[y].Length)
                    {
                        symbol = ' ';
                    }
                    else if (player.X == x && player.Y == y)
                    {
                        symbol = '#';
                    }
                    else
                    {
                        foreach (GameObject obj in objects)
                        {
                            if (obj.X == x && obj.Y == y)
                            {
                                symbol = GetSymbol(obj);
                            }
                        }
                    }

                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        public char GetSymbol(GameObject obj)
        {
            if (obj is Axe) return '*';
            if (obj is Torch) return '^';
            if (obj is Spider) return '@';
            return '.';
        }
    }


}
