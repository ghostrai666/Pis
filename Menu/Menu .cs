namespace Menu
{
    
    public class Menu
    {
        private List<MenuItem> items = new List<MenuItem>();

        public void Add(MenuItem item)
        {
            items.Add(item);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("пункты меню");

                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine((i) + " - " + items[i].Title);
                }

                Console.Write("Выберите пункт: ");



                string input = Console.ReadLine();

                int number = int.Parse(input);

                if ( number <= items.Count)
                {
                    items[number].Execute();
                }
                else
                {
                    Console.WriteLine("Нет такого пункта.");
                }
            }
        }
    }
}