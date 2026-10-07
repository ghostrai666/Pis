using System;
using System.Collections.Generic;
using System.Text;

namespace Pis1
{

    public class CurrencyRate
    {
        // КурсыВалют "Доллар" "Рубль" 84,80 2026.09.09

        public string Currency1 { get; set; }
        public string Currency2 { get; set; }
        public double Rate { get; set; }
        public string Date { get; set; }

        public static CurrencyRate Parser(string[] input)
        {
            return new CurrencyRate
            {
                Currency1 = input[1].Trim('"'),
                Currency2 = input[2].Trim('"'),
                Rate = Convert.ToDouble(input[3]),
                Date = input[4]
            };
        }
    }

    public class CryptoCurrencyRate : CurrencyRate
    {
        public string Exchange { get; set; }
        public bool IsVolatile { get; set; }

        public static CryptoCurrencyRate Parser(string[] input)
        {
            return new CryptoCurrencyRate
            {
                Currency1 = input[1].Trim('"'),
                Currency2 = input[2].Trim('"'),
                Rate = Convert.ToDouble(input[3]),
                Date = input[4],
                Exchange = input[5],
                IsVolatile = Convert.ToBoolean(input[6])
            };
        }
    }

    public class BankCurrencyRate : CurrencyRate
    {
        public string BankName { get; set; }
        public double Commission { get; set; }

        public new static BankCurrencyRate Parser(string[] input)
        {

            return new BankCurrencyRate
            {
                Currency1 = input[1].Trim('"'),
                Currency2 = input[2].Trim('"'),
                Rate = Convert.ToDouble(input[3]),
                Date = input[4],
                BankName = input[5],
                Commission = Convert.ToDouble(input[6])
            };
        }
    }

}
