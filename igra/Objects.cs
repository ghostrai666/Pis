using System;
using System.Collections.Generic;
using System.Text;

namespace igra
{
    public class GameObject
    {
        public int X;
        public int Y;
        public char Symbol;

        public GameObject(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Item : GameObject
    {
        public Item(int x, int y) : base(x, y)
        {

        }
    }

    public class Axe : Item
    {
        public Axe(int x, int y) : base(x, y)
        {

        }
    }

    public class Torch : Item
    {
        public Torch(int x, int y) : base(x, y)
        {

        }
    }

    public class Spider : GameObject
    {
        public Spider(int x, int y) : base(x, y)
        {

        }
    }

    public class Player : GameObject
    {
        public List<Item> Inventory = new List<Item>();
        public bool HasTorch = false;
        public bool HasAxe = false;
        public int View => HasTorch ? 3 : 2;

        public Player(int x, int y) : base(x, y)
        {

        }

        
    }
}
