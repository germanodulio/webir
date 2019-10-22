using System.ComponentModel.DataAnnotations;

using static Common.Enums;

namespace Common
{
    public class Currency
    {
        [Key]
        public CoinCode RefCode { get; set; }
        [Required]
        public string Name { get; set; } // Dolar, Peso Argentino, Dolar Blue
        [Required]
        public string CountryBank { get; set; } // Uruguay, Argentina


        internal Currency(string name, string countryBank, CoinCode refCode)
        {
            Name = name;
            CountryBank = countryBank;
            RefCode = refCode;
        }
    }
}
