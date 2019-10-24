﻿using Common;

using DataBaseConnector;

using Services;

using System;
using System.Collections.Generic;
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
                    dolarArg = ApiClients.GetQuotation(CoinCode.DolarArg);
                    dolarArg.Coin = dbMgr.GetCurrency(CoinCode.DolarArg);
                }

                //TODO consider Dollar Blue too?

                // Get Dollar quotation in Uruguay's central bank
                Quotation dolarUy = dbMgr.GetQuotation(CoinCode.DolarUy, date);
                if (dolarUy == null)
                {
                    dolarUy = ApiClients.GetQuotation(CoinCode.DolarUy);
                    dolarUy.Coin = dbMgr.GetCurrency(CoinCode.DolarUy);
                }

                // Get Peso Argentino quotation in Uruguay's central bank 
                Quotation pesoArgUy = dbMgr.GetQuotation(CoinCode.PesoArgUy, date);
                if (pesoArgUy == null)
                {
                    pesoArgUy = ApiClients.GetQuotation(CoinCode.PesoArgUy);
                    pesoArgUy.Coin = dbMgr.GetCurrency(CoinCode.PesoArgUy);
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

        public static object GetCotizationsBetween(List<string> codes, DateTime startTime, DateTime endTime)
        {
            // control dates validity
            if (startTime > endTime)
            {
                throw new Exception("La fecha de inicio no puede ser mayor a la de fin.");
            }

            if (endTime > DateTime.Today.Date)
            {
                throw new Exception("La fecha de fin no puede ser mayor a la fecha de hoy.");
            }

            List<List<Quotation>> result = new List<List<Quotation>>();
            DateTime iterator = startTime;
            DBManager mgr = new DBManager();
            while (iterator <= endTime)
            {
                List<Quotation> current = new List<Quotation>();
                foreach (string code in codes)
                {
                    if (Enum.TryParse(code, out CoinCode coinCode))
                    {
                        Quotation q = mgr.GetQuotation(coinCode, iterator);
                        if (q != null)
                        {
                            current.Add(q);
                        }
                    }
                }
                result.Add(current);
                iterator = iterator.AddDays(1);
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
            Quotation quotation = dbMgr.GetQuotation(coinCode, DateTime.Today.Date);

            if (quotation == null)
            {// Wasn't in DB, consume central bank WS
                quotation = ApiClients.GetQuotation(coinCode);
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
