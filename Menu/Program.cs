using TestMenu;

namespace Menu
{
    class Program
    {
        static void Main()
        {
            Menu menu = new Menu();

            menu.Add(new Item1("0 пункт"));
            menu.Add(new Item2("1 пункт"));

            menu.Run();
        }
    }
}