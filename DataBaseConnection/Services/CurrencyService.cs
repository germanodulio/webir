using Common.Repositories;

using System.Collections.Generic;
using static Common.Enums;

namespace Common.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository _currencyRepository;

        public CurrencyService()
        {
            _currencyRepository = new CurrencyRepository();
        }

        public Currency Get(CoinCode code)
        {
            return _currencyRepository.Get(code);
        }

        public List<Currency> GetAll()
        {
            return _currencyRepository.GetAll();
        }
    }
}
