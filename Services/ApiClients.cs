using Common;

using RestSharp;

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Uruguay;

using static Common.Enums;

namespace Services
{
    public class ApiClients
    {
        const string access_token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDE4NzE1MjMsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJnZXJvZHU5MUBnbWFpbC5jb20ifQ.OxgXbVmSWkG-F5woqunEYlCqNwwR2A3pn967RjSPUnitbbZ0QBsRm7zjAPiKeMVqInXu1-nHr3RvsKHgVutWMA";

        public static Quotation GetQuotation(CoinCode code)
        {
            if (code == CoinCode.DolarArg || code == CoinCode.DolarArgBlue)
            {
                return GetArgentinaLastCotization(code);
            }
            else
            {
                return GetUruguayLastCotization(code);
            }
        }

        private static async Task<ExecuteResponse> GetUruguayLastCotizationInternal(short coinCode)
        {
            wsbcucotizacionesin uy = new wsbcucotizacionesin();
            uy.Moneda = new short[] { coinCode };
            uy.FechaDesde = DateTime.Now.Date;
            uy.FechaHasta = DateTime.Now.Date;

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

        private static Quotation GetUruguayLastCotization(CoinCode code)
        {
            Quotation result = null;

            short coinCode = (short)(code == CoinCode.DolarUy ? 2222 : 500);
            Task<ExecuteResponse> response = GetUruguayLastCotizationInternal(coinCode);
            while (response.Status != TaskStatus.RanToCompletion) ;
            if (response.Result.Salida.respuestastatus.status == 1)
            {
                result = new Quotation();
                result.Date = response.Result.Salida.datoscotizaciones[0].Fecha.Value;
                result.Value = response.Result.Salida.datoscotizaciones[0].TCV;
            }

            return result;
        }

        private static Quotation GetArgentinaLastCotization(CoinCode coinCode)
        {
            string coin = coinCode == CoinCode.DolarArg ? "usd" : "usd_of";
            var client = new RestClient("https://api.estadisticasbcra.com/" + coin);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"BEARER {access_token}");
            //request.AddHeader("data", "{d:\"2018-12-31\"}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ErrorMessage);
            }
            DateTime lastDay = DateTime.Today.Date;
            while (!response.Content.Contains(lastDay.ToString("yyyy-MM-dd")))
            {
                lastDay = lastDay.AddDays(-1);
            }
            Quotation result = new Quotation();
            Regex todayRegexp = new Regex("\"d\":\"" + lastDay.ToString("yyyy-MM-dd") + "\",\"v\":[0-9]*.[0-9]*");
            if (todayRegexp.IsMatch(response.Content))
            {
                result.Date = lastDay;
                result.Value = double.Parse(todayRegexp.Match(response.Content).Value.Split("\"v\":")[1]);

                return result;
            }
            else
            {
                throw new Exception($"Could not find a cotization for {coin}. Make sure provided coin code is valid.");
            }
        }
    }
}
