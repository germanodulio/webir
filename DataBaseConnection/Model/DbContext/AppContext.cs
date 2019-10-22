using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class AppContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Currency dolarAr = new Currency("Dolar Oficial", "Argentina", Enums.CoinCode.DolarArg);
            Currency dolarArBlue = new Currency("Dolar Blue", "Argentina", Enums.CoinCode.DolarArgBlue);
            Currency dolarUy = new Currency("Dolar Uy", "Uruguay", Enums.CoinCode.DolarUy);
            Currency pesoArgUy = new Currency("Peso Argentino", "Uruguay", Enums.CoinCode.PesoArgUy);

            modelBuilder.Entity<Currency>().HasData(dolarAr, dolarArBlue, dolarUy, pesoArgUy);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        public AppContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
