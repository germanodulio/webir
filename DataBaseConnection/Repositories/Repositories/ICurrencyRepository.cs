using System.Collections.Generic;
using static Common.Enums;

namespace Common.Repositories
{
    public interface ICurrencyRepository
    {
        Currency Get(int currencyId);

        Currency Get(CoinCode code);

        List<Currency> GetAll();
    }
}
