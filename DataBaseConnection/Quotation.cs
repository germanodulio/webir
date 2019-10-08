using System;

namespace Common
{
    public class Quotation
    {
        public int Id { get; set; }
        public Currency Coin { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
