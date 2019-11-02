using Common;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Uruguay;

using static Common.Enums;

namespace Services
{
    public class ApiClients
    {
        const string access_token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDE4NzE1MjMsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJnZXJvZHU5MUBnbWFpbC5jb20ifQ.OxgXbVmSWkG-F5woqunEYlCqNwwR2A3pn967RjSPUnitbbZ0QBsRm7zjAPiKeMVqInXu1-nHr3RvsKHgVutWMA";

        public static List<Quotation> GetQuotation(CoinCode code, DateTime start, DateTime end)
        {
            if (code == CoinCode.DolarArg || code == CoinCode.DolarArgBlue)
            {
                return GetArgentinaCotization(code, Utils.GetValidDays(start, end));
            }
            else
            {
                return GetUruguayCotizations(code, start, end);
            }
        }

        private static async Task<ExecuteResponse> GetUruguayCotizationsInternal(short coinCode, DateTime start, DateTime end)
        {
            wsbcucotizacionesin uy = new wsbcucotizacionesin();
            uy.Moneda = new short[] { coinCode };
            uy.FechaDesde = start.Date;
            uy.FechaHasta = end.Date;

            wsbcucotizacionesSoapPortClient client = new wsbcucotizacionesSoapPortClient();

            await client.OpenAsync();
            ExecuteResponse response = await client.ExecuteAsync(uy);

            while (response != null && response.Salida != null && response.Salida.respuestastatus != null
                && response.Salida.respuestastatus.status == 0)
            {
                uy.FechaDesde = uy.FechaDesde.Value.AddDays(-1);
                uy.FechaHasta = uy.FechaDesde;
                response = await client.ExecuteAsync(uy);
            }

            return response;
        }

        private static List<Quotation> GetUruguayCotizations(CoinCode code, DateTime start, DateTime end)
        {
            List<Quotation> result = new List<Quotation>();

            short coinCode = (short)(code == CoinCode.DolarUy ? 2222 : 500);
            Task<ExecuteResponse> response = GetUruguayCotizationsInternal(coinCode, start, end);
            while (response.Status != TaskStatus.RanToCompletion) ;
            if (response.Result.Salida.respuestastatus.status == 1)
            {
                Quotation q = new Quotation();
                q.Date = response.Result.Salida.datoscotizaciones[0].Fecha.Value;
                q.Value = response.Result.Salida.datoscotizaciones[0].TCV;

                result.Add(q);
            }

            return result;
        }

        private static List<Quotation> GetArgentinaCotization(CoinCode coinCode, List<DateTime> dates)
        {
            string coin = coinCode == CoinCode.DolarArg ? "usd" : "usd_of";
            var client = new RestClient("https://api.estadisticasbcra.com/" + coin);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"BEARER {access_token}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("api.estadisticasbcra.com returned an error: " + response.ErrorMessage);
            }
            List<Quotation> results = new List<Quotation>();
            foreach (DateTime date in dates)
            {
                if (response.Content.Contains(date.ToString("yyyy-MM-dd")))
                {
                    Regex dateRegex = new Regex("\"d\":\"" + date.ToString("yyyy-MM-dd") + "\",\"v\":[0-9]*\\.?[0-9]*");
                    if (dateRegex.IsMatch(response.Content))
                    {
                        Quotation q = new Quotation();
                        q.Date = date;
                        string matched = dateRegex.Match(response.Content).Value;
                        if (!string.IsNullOrEmpty(matched))
                        {
                            q.Value = double.Parse(matched.Split("\"v\":")[1]);

                            results.Add(q);
                        }
                    }
                }
            }
            return results;
        }
    }
}
