using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Collections.Generic;
using System.IO;


namespace igra
{
    public class Program
    {
        static void Main()
        {
            Game game = new Game();

            game.Run();

            Console.WriteLine("");
        }
    }

}