using System;
using System.Collections.Generic;

using static Common.Enums;

namespace Common.Services
{
    public interface IQuotationService
    {
        int Add(Quotation quot);
        
        Quotation GetLastQuotation(CoinCode code);

        Quotation Get(CoinCode code, DateTime date);

        List<Quotation> GetAll();
    }
}
