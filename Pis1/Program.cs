using System.IO;

namespace PIS
{

    /// <summary>
    /// 15 вариант
    ///  равгвввввввввввввввво
    /// </summary>


    class CurrencyRate
    {
        public string Currency1;
        public string Currency2;
        public double Rate;
        public string Date;

        

        public static CurrencyRate Parser(string input)
        {
            string text = input.Trim();

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            string[] parts = text.Split(' ');

            // [курсывалют] [доллар] [рубль] [84,8] [2026.09.09]


            CurrencyRate tempCurrency = new CurrencyRate();

            // Trim('"') срезает кавычки по краям у строк
            tempCurrency.Currency1 = parts[1].Trim('"');
            tempCurrency.Currency2 = parts[2].Trim('"');
            tempCurrency.Rate = Convert.ToDouble(parts[3]);
            tempCurrency.Date = parts[4];

            return tempCurrency;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("введите пункт 1,2,3: ");

            while (true)
            {
                string newInput = Console.ReadLine();

                if (newInput == "3")
                {
                    break;
                }
                else if (newInput == "2")
                {
                    string input = Console.ReadLine();

                    CurrencyRate newCurrency = CurrencyRate.Parser(input);

                    Console.WriteLine($"Валюта 1: {newCurrency.Currency1}");
                    Console.WriteLine($"Валюта 2: {newCurrency.Currency2}");
                    Console.WriteLine($"Курс:     {newCurrency.Rate}");
                    Console.WriteLine($"Дата:     {newCurrency.Date}");
                }
            }
  
        }
    }
}

// КурсыВалют "Доллар" "Рубль" 84,80 2026.09.09

