using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI
{
    public class Program
    {
        private static IConfigurationRoot _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static string _port = _config.GetSection("AppSettings")["ServicePort"];
        public static async Task Main(string[] args)
        {
            //setting environment variable for base directory.
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);

            // Lets make sure that if creating web host fails, we can log that error.
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(_config)
               .CreateLogger();

            Log.Information("==============EcommerceAPI is starting up==============");
            using (var host = Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureWebHost(config =>
                {
                    config.UseUrls("http://*:" + _port);
                }).UseWindowsService()
                .Build())
            {
                try
                {
                    Log.Information("EcommerceAPI is up and running");
                    // Start the host
                    await host.StartAsync();
                    // Wait for the host to shutdown 
                    await host.WaitForShutdownAsync();
                    Log.Information("EcommerceAPI stopped");
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "EcommerceAPI failed to start correctly.");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }
    }
}
