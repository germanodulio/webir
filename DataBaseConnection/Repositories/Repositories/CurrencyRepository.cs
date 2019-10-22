using System;
using System.Collections.Generic;
using System.Linq;
using static Common.Enums;

namespace Common.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private AppContext _db;

        public CurrencyRepository()
        {
            ContextFactory contextFactory = new ContextFactory();
            _db =  contextFactory.CreateDbContext(new string[] { });
        }

        public Currency Get(int currencyId)
        {
            return _db.Currencies.Find(currencyId);
        }

        public Currency Get(CoinCode code)
        {
            IQueryable<Currency> cs = _db.Currencies.Where(c => c.RefCode == code);
            if (cs.Count() > 1)
            {
                Console.WriteLine($"More than one currency found with code {code}");
            }
            return cs.FirstOrDefault();
        }

        public List<Currency> GetAll()
        {
            return _db.Currencies.ToList();
        }
    }
}
