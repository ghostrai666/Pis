namespace PIS
{
    class CurrencyRate
    {
        public string Currency1;
        public string Currency2;
        public double Rate;
        public string Date;

        public static CurrencyRate Parser(string a)
        {
            // КурсыВалют "Доллар" "Рубль" 84,80 2026.09.09

            CurrencyRate tempCurrency = new CurrencyRate();

            string[] parts = a.Split('"');

            // [курсыВалют] [Доллар] [ ] [Рубль] [84,80 2026.09.09]

            tempCurrency.Currency1 = parts[1];
            tempCurrency.Currency2 = parts[3];

            // [84, 80 2026.09.09]

            string rateDateText = parts[4].Trim(); // .Trim удаляет пробелы до текста и после

            while (rateDateText.Contains("  "))
            {
                rateDateText = rateDateText.Replace("  ", " ");
            }

            string[] rateDate = rateDateText.Split(' ');

            tempCurrency.Rate = Convert.ToDouble(rateDate[0]);

            tempCurrency.Date = rateDate[1];

            return tempCurrency;

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            CurrencyRate newCurrency = CurrencyRate.Parser(input);


            Console.WriteLine($"Валюта 1: {newCurrency.Currency1}");
            Console.WriteLine($"Валюта 2: {newCurrency.Currency2}");
            Console.WriteLine($"курс: {newCurrency.Rate}");
            Console.WriteLine($"дата: {newCurrency.Date}");
        }
    }
}

// КурсыВалют "Доллар" "Рубль" 84,80 2026.09.09

// должно считываться с файла