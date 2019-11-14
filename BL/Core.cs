using Common;

using DataBaseConnector;

using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using static Common.Enums;

namespace BL
{
    public static class Core
    {
        public static Currency GetMostConvenientCurrency([Optional] DateTime date)
        {
            // 1 dollar based calculation. You are in Uruguay and will travel to Argentina, so...which currency will you carry?
            try
            {
                if (date == null)
                {
                    date = DateTime.Today;
                }
                else if (date > DateTime.Today)
                {
                    throw new Exception("Selected date can't be from future.");
                }

                List<DateTime> last2dates = Utils.GetLastDays(date, 2);
                if (last2dates == null || last2dates.Count != 2)
                {
                    throw new Exception($"Couldn't get two dates valid around {date.ToString()}");
                }

                // Get Dollar quotation in Argentina's central bank
                Quotation dolarArg = GetLastQuotation(CoinCode.DolarArg, last2dates[1], last2dates[0]);

                // Get Dollar quotation in Uruguay's central bank
                Quotation dolarUy = GetLastQuotation(CoinCode.DolarUy, last2dates[1], last2dates[0]);

                // Get Peso Argentino quotation in Uruguay's central bank 
                Quotation pesoArgUy = GetLastQuotation(CoinCode.PesoArgUy, last2dates[1], last2dates[0]);

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
                    return dolarArg.Coin;
                }
                else
                {
                    return pesoArgUy.Coin;
                }
            }
            catch
            {
                return null;
            }
        }

        public static void InitialLoad()
        {
            // Load last 10 cotizations
            List<DateTime> dates = Utils.GetLastDays(DateTime.Today.Date, 10);

            GetCotizations(new List<string>() { "DolarUy", "PesoArgUy", "DolarArg", "DolarBlue" }, dates);
        }

        public static object GetCotizationsBetween(List<string> codes, DateTime start, DateTime end)
        {
            // control dates validity
            if (start > end)
            {
                throw new Exception("La fecha de inicio no puede ser mayor a la de fin.");
            }

            if (end.Date > DateTime.Today.Date)
            {
                throw new Exception("La fecha de fin no puede ser mayor a la fecha de hoy.");
            }

            return GetCotizations(codes, Utils.GetValidDays(start, end));
        }

        public static object GetCotizations(List<string> codes, List<DateTime> days)
        {
            // control dates validity
            if (days == null || days.Count == 0)
            {
                throw new Exception("No se encontraron fechas.");
            }

            if (days.Any(d => !Utils.IsValidDay(d)))
            {
                throw new Exception("Hay alguna fecha inválida.");
            }

            List<List<Quotation>> result = new List<List<Quotation>>();

            DBManager mgr = new DBManager();

            foreach (string code in codes)
            {
                if (Enum.TryParse(code, out CoinCode coinCode))
                {

                    List<DateTime> missingDays = new List<DateTime>();
                    List<Quotation> current = mgr.GetQuotations(coinCode, days, ref missingDays);
                    foreach (DateTime day in missingDays)
                    {
                        List<Quotation> list = ApiClients.GetQuotation(coinCode, day, day);
                        Quotation q = null;
                        if (list != null && list.Count > 0)
                        {
                            q = list[0];
                        }

                        if (q != null)
                        {
                            q.Coin = mgr.GetCurrency(coinCode);
                            current.Add(q);
                            mgr.AddNewQuotation(q);
                        }
                    }
                    result.Add(current);
                }
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coinCode"></param>
        /// <returns></returns>
        public static Quotation GetLastQuotation(CoinCode coinCode)
        {
            List<DateTime> last2dates = Utils.GetLastDays(DateTime.Today, 2);
            return GetLastQuotation(coinCode, last2dates[1], last2dates[0]);
        }

        private static Quotation GetLastQuotation(CoinCode coin, DateTime best, DateTime alter)
        {
            DBManager dbMgr = new DBManager();
            Quotation result = dbMgr.GetQuotation(coin, best);
            if (result == null)
            {
                List<Quotation> quots = ApiClients.GetQuotation(coin, best, best);
                if (quots != null && quots.Count > 0)
                {
                    result = quots[0];
                    result.Coin = dbMgr.GetCurrency(coin);
                    dbMgr.AddNewQuotation(result);
                }
                else
                {
                    result = dbMgr.GetQuotation(coin, alter);

                    if (result == null)
                    {
                        quots = ApiClients.GetQuotation(coin, alter, alter);
                        if (quots != null && quots.Count > 0)
                        {
                            result = quots[0];
                            result.Coin = dbMgr.GetCurrency(coin);
                            dbMgr.AddNewQuotation(result);
                        }
                    }
                }
            }
            return result;
        }
    }
}
