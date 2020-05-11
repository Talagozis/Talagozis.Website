using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Talagozis.Logging;
using Talagozis.Logging.ColoredConsole;
using Talagozis.Logging.File;

namespace Talagozis.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, configurationBuilder) => 
                {
                    configurationBuilder.SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureKestrel((context, options) => options.AddServerHeader = true)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureServices(serviceCollection => serviceCollection.AddLoggerBackgroundService())
                .ConfigureLogging((hostingContext, loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);

                    loggingBuilder.AddFile(a =>
                    {
                        a.folderPath = Path.Combine(Directory.GetCurrentDirectory(), "../logs/");
                        a.Add(new FileLoggerConfiguration
                        {
                            logLevel = LogLevel.Information
                        });
                        a.Add(new FileLoggerConfiguration
                        {
                            logLevel = LogLevel.Warning
                        });
                        a.Add(new FileLoggerConfiguration
                        {
                            logLevel = LogLevel.Error
                        });
                        a.Add(new FileLoggerConfiguration
                        {
                            logLevel = LogLevel.Critical
                        });
                    });

                    loggingBuilder.AddColoredConsole(hostingContext.Configuration.GetSection("Logging:ColoredConsole"));
                });
        }
    }
}
