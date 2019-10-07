using RestSharp;

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Uruguay;

namespace Services
{
    public class ApiClients
    {
        const string access_token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDE4NzE1MjMsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJnZXJvZHU5MUBnbWFpbC5jb20ifQ.OxgXbVmSWkG-F5woqunEYlCqNwwR2A3pn967RjSPUnitbbZ0QBsRm7zjAPiKeMVqInXu1-nHr3RvsKHgVutWMA";

        public static async Task<ExecuteResponse> GetUruguayLastCotizationForCoin(short coinCode)
        {
            wsbcucotizacionesin uy = new wsbcucotizacionesin();
            uy.Moneda = new short[] { coinCode };
            uy.FechaDesde = DateTime.Now.Date;
            uy.FechaHasta = DateTime.Now.Date;

            wsbcucotizacionesSoapPortClient client = new wsbcucotizacionesSoapPortClient();

            await client.OpenAsync();
            ExecuteResponse response = await client.ExecuteAsync(uy);

            while (response.Salida.respuestastatus.status == 0)
            {
                uy.FechaDesde = uy.FechaDesde.Value.AddDays(-1);
                uy.FechaHasta = uy.FechaDesde;
                response = await client.ExecuteAsync(uy);
            }

            return response;
        }

        public static string GetArgentinaLastCotization(string coin)
        {
            var client = new RestClient("https://api.estadisticasbcra.com/" + coin);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"BEARER {access_token}");
            //request.AddHeader("data", "{d:\"2018-12-31\"}");
            IRestResponse response = client.Execute(request);
            DateTime lastDay = DateTime.Today;
            while (!response.Content.Contains(lastDay.ToString("yyyy-MM-dd")))
            {
                lastDay = lastDay.AddDays(-1);
            }
            Regex todayRegexp = new Regex("\"d\":\"" + lastDay.ToString("yyyy-MM-dd") + "\",\"v\":[0-9]*.[0-9]*");
            if (todayRegexp.IsMatch(response.Content))
            {
                return $"Fecha: {lastDay.ToString("yyyy-MM-dd")}, Valor: {todayRegexp.Match(response.Content).Value.Split("\"v\":")[1]}";
            }
            return response.Content;
        }
    }
}
