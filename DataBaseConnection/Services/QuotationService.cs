using Common.Repositories;

using System;
using System.Collections.Generic;

using static Common.Enums;

namespace Common.Services
{
    public class QuotationService : IQuotationService
    {
        private ICurrencyRepository _currencyRepository;
        private IQuotationRepository _quotationRepository;

        public QuotationService()
        {
            _currencyRepository = new CurrencyRepository();
            _quotationRepository = new QuotationRepository();
        }

        public int Add(Quotation quot)
        {
            return _quotationRepository.Add(quot);
        }

        public Quotation Get(CoinCode code, DateTime date)
        {
            return _quotationRepository.GetQuotation(code, date);
        }

        public List<Quotation> GetAll()
        {
            return _quotationRepository.GetAll();
        }

        public Quotation GetLastQuotation(CoinCode code)
        {
            return _quotationRepository.GetLastQuotation(code);
        }
    }
}
