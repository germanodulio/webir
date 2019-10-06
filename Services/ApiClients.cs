using System;
using Uruguay;

namespace Services
{
    public class ApiClients
    {
        public static async System.Threading.Tasks.Task<ExecuteResponse> GetLastCotizationForCoin(short coinCode)
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
    }
}
