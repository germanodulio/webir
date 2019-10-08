using System;

using static Common.Utils;

namespace Common
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } // Dolar, Peso Argentino, Dolar Blue
        public string CountryBank { get; set; } // Uruguay, Argentina
        /// <summary>
        /// 2222 dolar en Uruguay
        /// 500 peso argentino en Uruguay
        /// usd dolar blue en argentina
        /// usd_of dolar oficial en argentina
        /// </summary>
        public CoinCode RefCode { get; set; }


        public Currency(string name, string bank, CoinCode code)
        {
            Name = name;
            CountryBank = bank;
            RefCode = code;
        }

        public static Currency GetCoinForCode(CoinCode coinCode)
        {
            switch (coinCode)
            {
                case CoinCode.DolarArg:
                    return new Currency("Dolar", "Argentina", coinCode);
                case CoinCode.DolarBlue:
                    return new Currency("Dolar Blue", "Argentina", coinCode);
                case CoinCode.DolarUy:
                    return new Currency("Dolar", "Uruguay", coinCode);
                case CoinCode.PesoArgUy:
                    return new Currency("Peso Argentino", "Uruguay", coinCode);
                default:
                    return null;
            }
        }

        // 1 | Dolar          | Uruguay     | 2222
        // 2 | Peso Argentino | Uruguay     | 500
        // 3 | Dolar Blue     | Argentina   | usd
        // 4 | Dolar          | Argentina   | usd_of
    }
}
