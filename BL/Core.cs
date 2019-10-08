using Common;

using DataBaseConnector;

using Services;

using System;
using System.Runtime.InteropServices;

using static Common.Utils;

namespace BL
{
    public static class Core
    {
        public static Currency GetMostConvenientCurrency([Optional] DateTime date)
        {
            // 1 dollar based calculation. You are in Uruguay and will travel to Argentina, so...which currency will you carry?
            try
            {
                // Get Dollar quotation in Argentina's central bank
                Quotation dolarArg = Manager.GetQuotation(CoinCode.DolarArg, date);
                if (dolarArg == null)
                {
                    dolarArg = ApiClients.GetQuotation(CoinCode.DolarArg);
                }
                //TODO consider Dollar Blue too?

                // unDolarEnPesosArgentinosEnUy = con el valor correspondiente a un dolar en pesos uruguayos: cuantos pesos argentinos compro?

                // Get Dollar quotation in Uruguay's central bank
                Quotation dolarUy = Manager.GetQuotation(CoinCode.DolarUy, date);
                if (dolarUy == null)
                {
                    dolarUy = ApiClients.GetQuotation(CoinCode.DolarUy);
                }

                // Get Peso Argentino quotation in Uruguay's central bank 
                Quotation pesoArgUy = Manager.GetQuotation(CoinCode.PesoArgUy, date);
                if (pesoArgUy == null)
                {
                    pesoArgUy = ApiClients.GetQuotation(CoinCode.PesoArgUy);
                }

                // How many Peso Argentino's can you get with 1 dollar in Uruguay?
                double withOneDollarYouGetArgPeso = 0;
                if (pesoArgUy != null && dolarUy != null)
                {
                    withOneDollarYouGetArgPeso = dolarUy.Value / pesoArgUy.Value;
                }


                // si dollarArg > unDolarEnPesosArgentinosEnUy entonces conviene llevar dolares y cambiarlos en Argentina a pesos argentinos
                // sino comprar pesos argentinos en Uruguay para llevar 
                if (dolarArg.Value > withOneDollarYouGetArgPeso)
                {
                    return Currency.GetCoinForCode(CoinCode.DolarArg);
                }
                else
                {
                    return Currency.GetCoinForCode(CoinCode.PesoArgUy);
                }
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coinCode"></param>
        /// <returns></returns>
        public static Quotation GetLastQuotation(CoinCode coinCode)
        {
            // TODO if it is not stored in DB, use Api services to get it and store it in DB
            Quotation quotation = Manager.GetQuotation(coinCode);

            if (quotation == null)
            {
                quotation = ApiClients.GetQuotation(coinCode);
            }

            return quotation;
        }
    }
}
