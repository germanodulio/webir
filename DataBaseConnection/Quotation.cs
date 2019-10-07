using System;

namespace Common
{
    public class Quotation
    {
        public int Id { get; set; }
        public Currency Coin { get; set; }
        public double Purchase { get; set; }
        public double Sale { get; set; }
        public DateTime Date { get; set; }
    }
}
