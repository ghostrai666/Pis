using System;
using System.Collections.Generic;
using System.Text;

namespace Pis1
{
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
}
