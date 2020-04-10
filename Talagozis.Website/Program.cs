using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Talagozis.AspNetCore.Services.Logger;
using Talagozis.AspNetCore.Services.Logger.ColoredConsole;

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
                    .ConfigureKestrel((context, options) => { })
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseApplicationInsights()
                    .ConfigureServices(serviceCollection =>
                    {
                        serviceCollection.AddHostedService<LoggerBackgroundService>();
                        serviceCollection.AddSingleton<LoggerBackgroundQueue>();
                    })
                    .ConfigureLogging((hostingContext, loggingBuilder) =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging")); 
                        loggingBuilder.SetMinimumLevel(LogLevel.Trace);

                        loggingBuilder.AddColoredConsole(a =>
                        {
                            a.Add(new ColoredConsoleLoggerConfiguration
                            {
                                Color = ConsoleColor.Yellow,
                                EventId = 101,
                                LogLevel = LogLevel.Warning,
                            });
                            a.Add(new ColoredConsoleLoggerConfiguration
                            {
                                Color = ConsoleColor.Cyan,
                                EventId = 101,
                                LogLevel = LogLevel.Information,
                            });
                            a.Add(new ColoredConsoleLoggerConfiguration
                            {
                                Color = ConsoleColor.Gray,
                                EventId = 101,
                                LogLevel = LogLevel.Debug,
                            });
                            a.Add(new ColoredConsoleLoggerConfiguration
                            {
                                Color = ConsoleColor.DarkMagenta,
                                EventId = 101,
                                LogLevel = LogLevel.Trace,
                            });
                        });

                    });
        }
    }
}
