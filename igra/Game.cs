using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace igra
{
    public class Game
    {
        Player player;
        ConsoleRender consRender = new ConsoleRender();
        List<GameObject> objects = new List<GameObject>();

        public static char[,] LoadMap(string filePath)
        {
            // проверка на существование
            if (!File.Exists(filePath))
            {
                throw new Exception($"Файл карты не найден");
            }

            string[] lines = File.ReadAllLines(filePath);

            // проверка на непустоту
            if (lines.Length == 0)
            {
                throw new Exception("Файл карты пуст.");
            }

            // проверка на наличие игрока 
            if (!lines.Any(line => line.Contains('#')))
            {
                throw new Exception("В файле нет игрока");
            }


            // создание карты
            int height = lines.Length;
            int width = lines[0].Length;

            char[,] map = new char[height, width];


            for (int y = 0; y < height; y++)
            {
                // проверка на квадратность
                if (lines[y].Length != width)
                {
                    throw new Exception($"Ошибка в строке {y}: несоответствие ширины карты.");
                }

                for (int x = 0; x < width; x++)
                {
                    char c = lines[y][x];

                    if (c != '#' && c != ' ' && c != '.' && c != '@' && c != '*' && c != '^')
                    {
                        throw new Exception($"Обнаружен недопустимый символ '{c}' в позиции [{y}, {x}].");
                    }

                    map[y, x] = c;
                }
            }

            return map;
        }



        public void LoadMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    char c = map[y, x];

                    if (c == '#')
                    {
                        player = new Player(x, y);
                    }
                    else if (c == '*')
                    {
                        objects.Add(new Axe(x, y));
                    }
                    else if (c == '^')
                    {
                        objects.Add(new Torch(x, y));
                    }
                    else if (c == '@')
                    {
                        objects.Add(new Spider(x, y));
                    }
                }
            }
        }

        public void Run()
        {
            string filePath = "map.txt";

            char[,] map = LoadMap(filePath);

            LoadMap(map);

            //player.HasTorch = true;

            consRender.Draw(map, player, objects);

        }
    }



}
