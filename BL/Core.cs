﻿using Common;

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
                DBManager dbMgr = new DBManager();

                // Get Dollar quotation in Argentina's central bank
                Quotation dolarArg = dbMgr.GetQuotation(CoinCode.DolarArg, date);
                if (dolarArg == null)
                {
                    dolarArg = ApiClients.GetQuotation(CoinCode.DolarArg, date, date)[0];
                    dolarArg.Coin = dbMgr.GetCurrency(CoinCode.DolarArg);

                    dbMgr.AddNewQuotation(dolarArg);
                }

                //TODO consider Dollar Blue too?

                // Get Dollar quotation in Uruguay's central bank
                Quotation dolarUy = dbMgr.GetQuotation(CoinCode.DolarUy, date);
                if (dolarUy == null)
                {
                    dolarUy = ApiClients.GetQuotation(CoinCode.DolarUy, date, date)[0];
                    dolarUy.Coin = dbMgr.GetCurrency(CoinCode.DolarUy);
                    dbMgr.AddNewQuotation(dolarUy);
                }

                // Get Peso Argentino quotation in Uruguay's central bank 
                Quotation pesoArgUy = dbMgr.GetQuotation(CoinCode.PesoArgUy, date);
                if (pesoArgUy == null)
                {
                    pesoArgUy = ApiClients.GetQuotation(CoinCode.PesoArgUy, date, date)[0];
                    pesoArgUy.Coin = dbMgr.GetCurrency(CoinCode.PesoArgUy);
                    dbMgr.AddNewQuotation(pesoArgUy);
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
            // Load last 7 cotizations
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
                        result.Add(current);
                    }
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
            DBManager dbMgr = new DBManager();

            // Try to get it from DB for today
            DateTime lastValidDay = DateTime.Today.Date;
            while (!Utils.IsValidDay(lastValidDay))
            {
                lastValidDay = lastValidDay.AddDays(-1);
            }
            Quotation quotation = dbMgr.GetQuotation(coinCode, lastValidDay);

            if (quotation == null)
            {// Wasn't in DB, consume central bank WS
                List<Quotation> quots = ApiClients.GetQuotation(coinCode, lastValidDay, lastValidDay);
                while (quots == null || quots.Count == 0)
                {
                    lastValidDay = lastValidDay.AddDays(-1);
                    quots = ApiClients.GetQuotation(coinCode, lastValidDay, lastValidDay);
                }

                quotation = quots[0];
                quotation.Coin = dbMgr.GetCurrency(coinCode);

                // Add new quotation to DB if it is new
                if (!dbMgr.QuotationExists(quotation))
                {
                    dbMgr.AddNewQuotation(quotation);
                }
            }

            return quotation;
        }
    }
}
