using System.IO;

namespace Pis1
{
    /// 15 вариант
    
    internal class Program
    {

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. запарсить строку");
                Console.WriteLine("2. запарсить файл");
                Console.WriteLine("3. выйти");
                Console.Write("введите пункт 1,2: ");

                string Input = Console.ReadLine();

                Console.Clear();

                if (Input == "1")
                {
                    Console.Write("Введите строку: ");
                    string input = Console.ReadLine();

                    CurrencyRate rate = Handlers.ParseAny(input);
                    Handlers.PrintRate(rate);

                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Input == "2")
                {
                    string path = "data.txt";

                    string[] lines = File.ReadAllLines(path);

                    foreach (string line in lines)
                    {
                        CurrencyRate rate = Handlers.ParseAny(line);
                        Handlers.PrintRate(rate);
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Input == "3")
                {
                    break;
                }
            }
        }
    }
}


// КурсыВалют "Доллар" "Рубль" 84,80 2026.09.09
// КриптоКурс BTC USDT 62500,50 2026.09.09 Binance true
// БанковскийКурс USD RUB 85,50 2026.09.09 Сбербанк 1,5

// C:\Users\kotov\source\repos\Pis1

// https://github.com/ghostrai666/Pis.git
