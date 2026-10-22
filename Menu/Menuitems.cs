namespace TestMenu
{
    public class Item1 : MenuItem
    {

        public Item1(string name)
        {
            Title = name;
        }

        public override void Execute()
        {

            Console.WriteLine("11");
        }
    }

    public class Item2 : MenuItem
    {

        public Item2(string name)
        {
            Title = name;
        }

        public override void Execute()
        {
            Console.WriteLine("22");
        }
    }

    
}