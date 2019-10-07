using Common;
using System;

namespace BL
{
    public static class Core
    {
        public static Currency GetMostConvenientCurrency(DateTime date)
        {
            // TODO define calculation needed to resolve this
            throw new NotImplementedException();
        }

        public static Quotation GetLastQuotation(int currencyId)
        {
            // TODO if it is not stored in DB, use Api services to get it and store it in DB
            throw new NotImplementedException();
        }
    }
}
