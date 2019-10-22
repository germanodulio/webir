using Common;
using Common.Services;

using System;

using static Common.Enums;

namespace DataBaseConnector
{
    public class DBManager
    {
        private IQuotationService _quotationSrv;
        private ICurrencyService _currencySrv;

        public DBManager()
        {
            _quotationSrv = new QuotationService();
            _currencySrv = new CurrencyService();
        }

        public void AddNewQuotation(Quotation quotation)
        {
            _quotationSrv.Add(quotation);
        }

        public Quotation GetQuotation(CoinCode code, DateTime date)
        {
            return _quotationSrv.Get(code, date);
        }

        public Currency GetCurrency(CoinCode code)
        {
            return _currencySrv.Get(code);
        }

        internal bool QuotationExists(Quotation quotation)
        {
            return _quotationSrv.Get(code: quotation.Coin.RefCode, date: quotation.Date) != null;
        }
    }
}
