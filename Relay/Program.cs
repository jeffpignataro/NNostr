using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Relay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureAppConfiguration(builder =>
                {
                    var activeEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    builder.AddJsonFile($"appsettings.json", false, true);
                    builder.AddJsonFile($"appsettings.{activeEnvironment}.json", false, true);
                    builder.AddEnvironmentVariables("NOSTR_");
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}