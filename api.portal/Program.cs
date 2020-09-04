using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting;

namespace Api.Portal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static string LogPath
        {
            get
            {
                return Environment.CurrentDirectory + "\\LogFiles\\Log.txt";
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog((builder, logger) =>
                    {

                        if (builder.HostingEnvironment.IsDevelopment()
                        || builder.HostingEnvironment.IsProduction())
                        {

                            logger.WriteTo.File(
                            LogPath,
                            fileSizeLimitBytes: 1024 * 500000,
                            rollOnFileSizeLimit: true,
                            shared: true,
                            flushToDiskInterval: TimeSpan.FromSeconds(1));
                        }

                    });

                });
    }
}
