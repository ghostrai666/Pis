using System;
using System.Collections.Generic;
using System.Text;

namespace igra
{
    public class ConsoleRender
    {
        public void Draw(char[,] map, Player player, List<GameObject> objects)
        {
            int radius = player.View;

            for (int y = player.Y - radius; y <= player.Y + radius; y++)
            {
                for (int x = player.X - radius; x <= player.X + radius; x++)
                {
                    char symbol = '.';


                    if (y < 0 || y >= map.GetLength(0) || x < 0 || x >= map.GetLength(1)) // отрисовка границ
                    {
                        symbol = ' ';
                    }
                    else if (player.X == x && player.Y == y) // отрисовка игрока
                    {
                        symbol = '#'; 
                    }
                    else
                    {
                        foreach (GameObject obj in objects) // отрисовка предметов
                        {
                            if (obj.X == x && obj.Y == y)
                            {
                                symbol = GetSymbol(obj);
                                break;
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
