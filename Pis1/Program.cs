using System.IO;

namespace Pis1
{

    /// <summary>
    /// 15 вариант
    /// </summary>

    public static class Handlers // обработчик строк
    {
        public static string[] Handler(string input)
        {
            string text = input.Trim();

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            string[] parts = text.Split(" ");

            return parts;
        }

        public static CurrencyRate ParseAny(string input)
        {
            // Готовим массив один раз для любого типа курса
            string[] parts = Handlers.Handler(input);

            if (parts[0] == "КриптоКурс")
            {
                return CryptoCurrencyRate.Parser(parts);
            }
            else if (parts[0] == "БанковскийКурс")
            {
                return BankCurrencyRate.Parser(parts);
            }

            return CurrencyRate.Parser(parts);
        }

        public static void PrintRate(CurrencyRate rate)
        {
            Console.WriteLine($"Валюта 1: {rate.Currency1}");
            Console.WriteLine($"Валюта 2: {rate.Currency2}");
            Console.WriteLine($"Курс:     {rate.Rate}");
            Console.WriteLine($"Дата:     {rate.Date}");

            // если is вернул true, rate приводится к CryptoCurrencyRate и записывается в crypto
            if (rate is CryptoCurrencyRate crypto)
            {
                Console.WriteLine($"Сеть:     {crypto.Exchange}");
                Console.WriteLine($"Волатильность: {crypto.IsVolatile}");
            }
            else if (rate is BankCurrencyRate bank)
            {
                Console.WriteLine($"Банк:     {bank.BankName}");
                Console.WriteLine($"Комиссия: {bank.Commission}%");
            }

            Console.WriteLine(new string('-', 35));
        }
    }

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

                    CurrencyRate rate = ParseAny(input);
                    PrintRate(rate);

                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Input == "2")
                {
                    string path = "data.txt";

                    string[] lines = File.ReadAllLines(path);

                    foreach (string line in lines)
                    {
                        CurrencyRate rate = ParseAny(line);
                        PrintRate(rate);
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
