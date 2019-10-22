using System;
using System.Collections.Generic;

using static Common.Enums;

namespace Common.Repositories
{
    public interface IQuotationRepository
    {
        int Add(Quotation q);

        Quotation Get(int quotationId);

        Quotation GetLastQuotation(CoinCode code);

        Quotation GetQuotation(CoinCode code, DateTime date);

        List<Quotation> GetAll();
    }
}
