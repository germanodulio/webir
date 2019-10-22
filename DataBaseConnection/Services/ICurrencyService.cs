using System.Collections.Generic;
using static Common.Enums;

namespace Common.Services
{
    public interface ICurrencyService
    {
        Currency Get(CoinCode code);

        List<Currency> GetAll();
    }
}
