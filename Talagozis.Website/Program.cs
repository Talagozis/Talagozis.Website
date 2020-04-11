using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Talagozis.AspNetCore.Services.Logger;
using Talagozis.AspNetCore.Services.Logger.ColoredConsole;
using Talagozis.AspNetCore.Services.Logger.File;
using Talagozis.AspNetCore.Services.Logger.Trace;

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
            return new WebHostBuilder()
                .UseKestrel()
                .ConfigureKestrel((context, options) => options.AddServerHeader = true)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
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
#if DEBUG
                    loggingBuilder.AddColoredConsole(a =>
                    {
                        a.Add(new ColoredConsoleLoggerConfiguration
                        {
                            color = ConsoleColor.Red,
                            logLevel = LogLevel.Error,
                        });
                        a.Add(new ColoredConsoleLoggerConfiguration
                        {
                            color = ConsoleColor.Yellow,
                            logLevel = LogLevel.Warning,
                        });
                        a.Add(new ColoredConsoleLoggerConfiguration
                        {
                            namespacePrefix = "Talagozis",
                            color = ConsoleColor.Green,
                            logLevel = LogLevel.Information,
                        });
                        a.Add(new ColoredConsoleLoggerConfiguration
                        {
                            namespacePrefix = "Talagozis",
                            color = ConsoleColor.DarkCyan,
                            logLevel = LogLevel.Debug,
                        });
                        a.Add(new ColoredConsoleLoggerConfiguration
                        {
                            namespacePrefix = "Talagozis",
                            color = ConsoleColor.White,
                            logLevel = LogLevel.Trace,
                        });
                    });
#endif
                });
        }
    }
}
