using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using Services;

using System.Threading.Tasks;

using Uruguay;

namespace webirBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("http://api.estadisticasbcra.com");
            var request = new RestRequest("usd_of", Method.GET);
            //request.AddHeader("referer", "http://api.estadisticasbcra.com/usd_of");
            string access_token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDE4NzE1MjMsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJnZXJvZHU5MUBnbWFpbC5jb20ifQ.OxgXbVmSWkG-F5woqunEYlCqNwwR2A3pn967RjSPUnitbbZ0QBsRm7zjAPiKeMVqInXu1-nHr3RvsKHgVutWMA";
            request.AddParameter("Authorization", string.Format("BEARER " + access_token), ParameterType.HttpHeader);
            //request.AddHeader("Authorization", $"BEARER {access_token}");
            //request.AddHeader("Accept", "application/json");
            //request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
