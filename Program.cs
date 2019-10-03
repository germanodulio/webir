using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services;
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
