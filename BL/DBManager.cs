using Common;
using Common.Services;

using System;
using System.Collections.Generic;
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
            Quotation result = _quotationSrv.Get(code, date);
            if (result != null)
            {
                result.Coin = _currencySrv.Get(code);
            }

            return result;
        }

        public Currency GetCurrency(CoinCode code)
        {
            return _currencySrv.Get(code);
        }

        internal bool QuotationExists(Quotation quotation)
        {
            return _quotationSrv.Get(code: quotation.Coin.RefCode, date: quotation.Date) != null;
        }

        internal List<Quotation> GetQuotations(CoinCode coinCode, List<DateTime> days, ref List<DateTime> missingDays)
        {
            List<Quotation> result = new List<Quotation>();
            foreach (DateTime day in days)
            {
                Quotation q = _quotationSrv.Get(coinCode, day);
                if (q != null)
                {
                    q.Coin = _currencySrv.Get(coinCode);
                    result.Add(q);
                }
                else
                {
                    missingDays.Add(day);
                }
            }
            return result;
        }
    }
}
