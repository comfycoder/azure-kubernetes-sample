using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace KubeSampleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseApplicationInsights()
        //        .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;

                    if (env.IsDevelopment())
                    {
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                             .AddEnvironmentVariables();
                    }
                    else
                    {
                        config.AddJsonFile("KubeSampleApi/appsettings.json", optional: false, reloadOnChange: true)
                             .AddJsonFile($"KubeSampleApi/appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                             .AddJsonFile("/app/AppConfig.json", optional: false, reloadOnChange: true)
                             .AddEnvironmentVariables();
                    }

                    var builtConfig = config.Build();

                    var isVaultEnabled = builtConfig["AppConfiguration:IsVaultEnabled"];

                    if ( !string.IsNullOrWhiteSpace(isVaultEnabled) && Convert.ToBoolean(isVaultEnabled))
                    {
                        var keyVaultName = builtConfig["KeyVaultName"];
                        var clientId = builtConfig["AzureAd:ClientId"];
                        var clientSecret = builtConfig["AzureAd:ClientSecret"];

                        config.AddAzureKeyVault(
                            $"https://{keyVaultName}.vault.azure.net/",
                            clientId,
                            clientSecret);
                    }                        
                })
                .UseStartup<Startup>();
    }
}
