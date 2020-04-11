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

//                        loggingBuilder.AddFile(a =>
//                        {
//                            a.folderPath = Path.Combine(Directory.GetCurrentDirectory(), "../logs/");
//                            a.Add(new FileLoggerConfiguration
//                            {
//                                //eventId = 0,
//                                logLevel = LogLevel.Warning
//                            });
//                            a.Add(new FileLoggerConfiguration
//                            {
//                                //eventId = 0,
//                                logLevel = LogLevel.Error
//                            });
//                            a.Add(new FileLoggerConfiguration
//                            {
//                                //eventId = 0,
//                                logLevel = LogLevel.Critical
//                            });
//                        });
//#if DEBUG
//                        loggingBuilder.AddTrace(a =>
//                        {
//                            //a.eventId 0 
//                        });

//                        loggingBuilder.AddColoredConsole(a =>
//                        {
//                            a.Add(new ColoredConsoleLoggerConfiguration
//                            {
//                                namespacePrefix = "",
//                                color = ConsoleColor.Yellow,
//                                logLevel = LogLevel.Warning,
//                            });
//                            a.Add(new ColoredConsoleLoggerConfiguration
//                            {
//                                namespacePrefix = "",
//                                color = ConsoleColor.Cyan,
//                                logLevel = LogLevel.Information,
//                            });
//                            a.Add(new ColoredConsoleLoggerConfiguration
//                            {
//                                namespacePrefix = "Talagozis",
//                                color = ConsoleColor.Gray,
//                                logLevel = LogLevel.Debug,
//                            });
//                            a.Add(new ColoredConsoleLoggerConfiguration
//                            {
//                                namespacePrefix = "Talagozis",
//                                color = ConsoleColor.DarkMagenta,
//                                logLevel = LogLevel.Trace,
//                            });
//                        });
//#endif
                    });
        }
    }
}
