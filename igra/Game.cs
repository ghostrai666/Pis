using System;
using System.Collections.Generic;
using System.Text;

namespace igra
{
    class Game
    {
        Player player;
        ConsoleRender consrender = new ConsoleRender();
        List<GameObject> objects = new List<GameObject>();

        public void LoadMap(string[] map) 
        {

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    char c = map[y][x];

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
            string[] map = File.ReadAllLines("map.txt");

            LoadMap(map);

            //player.HasTorch = true;

            consrender.Draw(map, player, objects);

        }
    }

    

}
