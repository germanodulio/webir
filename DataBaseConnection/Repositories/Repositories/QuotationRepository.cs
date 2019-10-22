using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

using static Common.Enums;

namespace Common.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private AppContext _db;

        public QuotationRepository()
        {
            ContextFactory contextFactory = new ContextFactory();
            _db = contextFactory.CreateDbContext(new string[] { });
        }

        public int Add(Quotation q)
        {
            q.Id = 0;
            _db.Quotations.Add(q);
            _db.Entry(q.Coin).State = EntityState.Detached;
            _db.SaveChanges();
            return q.Id;
        }

        public Quotation Get(int quotationId)
        {
            return _db.Quotations.Find(quotationId);
        }

        public List<Quotation> GetAll()
        {
            return _db.Quotations.ToList();
        }

        public Quotation GetLastQuotation(CoinCode code)
        {
            IQueryable<Quotation> quotations = _db.Quotations.Where(q => q.Coin.RefCode == code);
            if (quotations.Count() > 0)
            {
                quotations = quotations.OrderBy(q => q.Date);
                return quotations.Last();
            }
            return null;
        }

        public Quotation GetQuotation(CoinCode code, DateTime date)
        {
            return _db.Quotations.Where(q => q.Coin.RefCode == code && q.Date.Equals(date)).FirstOrDefault();
        }
    }
}
