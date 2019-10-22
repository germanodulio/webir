using Common;
using Common.Services;
using System;
using System.Runtime.InteropServices;
using static Common.Utils;

namespace DataBaseConnector
{
    public class Manager
    {
        private IQuotationService _quotationSrv;
        private ICurrencyService _currencySrv;

        public Manager()
        {
            _quotationSrv = new QuotationService();
            _currencySrv = new CurrencyService();
        }

        public void AddNewQuotation(Quotation quotation)
        {
            _quotationSrv.Add(quotation);
        }

        public Quotation GetQuotation(CoinCode code, [Optional] DateTime date)
        {
            Currency currency = _currencySrv.Get(code);
            return _quotationSrv.Get(currency.Id, date);
        }
    }
}
