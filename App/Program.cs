using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using Services;

using System.Threading.Tasks;

using Uruguay;

namespace webirBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get Peso Argentino cotization
            Task<ExecuteResponse> response = ApiClients.getValueAsync(500);

            ExecuteResponse result = response.Result;

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
