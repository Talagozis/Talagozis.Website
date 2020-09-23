using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.AspNetCore.Identity.SQLServer;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Piranha.AttributeBuilder;
using Piranha.Cache;
using Piranha.Manager.Editor;
using Talagozis.AspNetCore.Extensions;
using Talagozis.Payments.Paypal;
using WebMarkupMin.AspNetCore2;
using Piranha.Data.EF.SQLServer;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
using Talagozis.Website.Models.Cms.SiteTypes;

namespace Talagozis.Website
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this._configuration = configuration;
            this._env = env;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews()
#if DEBUG
                .AddRazorRuntimeCompilation()
#endif
                ;
            services.AddRazorPages().AddPiranhaManagerOptions()
#if DEBUG
                .AddRazorRuntimeCompilation()
#endif
                ;

            services.AddHttpsRedirection(options => options.HttpsPort = 443);

            services.configureServices(this._configuration);

            services.AddOptions();

            services.AddPaypalService(this._configuration.GetSection("Paypal"));

            services.AddWebMarkupMin(options => { options.DisablePoweredByHttpHeaders = true; }).AddHtmlMinification().AddHttpCompression();

            services.AddApplicationInsightsTelemetry();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api, ILogger<Startup> logger)
        {
            app.UseExceptionHandlerLogger(ex => logger.LogError(ex, ex.Message));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"../uploads")),
                RequestPath = new PathString("/uploads"),
                OnPrepareResponse = ctx => ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + 60 * 60 * 24 * 366
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    TimeSpan age = new TimeSpan(366, 0, 0, 0); 
                    if (string.Equals(ctx.File.Name, "service-worker.js", StringComparison.CurrentCultureIgnoreCase))
                        age = new TimeSpan(0, 0, 0, 0);

                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + age.TotalSeconds.ToString("0");
                }
            });
            app.UseWebMarkupMin();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            api.configuration();
            app.usePiranhaCms();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "areaRoute",
                //    pattern: "{area:exists}/{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "defaultHome",
                    pattern: "{action}",
                    defaults: new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                endpoints.MapRazorPages();
                endpoints.MapPiranhaManager();
            });
        }
    }

    internal static class PiranhaConfiguration
    {
        internal static void configureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "../uploads"));

            services.AddPiranha(piranhaServiceBuilder =>
            {
                piranhaServiceBuilder.UseFileStorage(Path.Combine(Directory.GetCurrentDirectory(), @"../uploads/"), "~/uploads/");
                piranhaServiceBuilder.UseImageSharp();
                piranhaServiceBuilder.UseManager();
                piranhaServiceBuilder.UseTinyMCE();
                piranhaServiceBuilder.UseMemoryCache();
                piranhaServiceBuilder.UseEF<SQLServerDb>(options => options.UseSqlServer(configuration.GetConnectionString("PiranhaConnection")));
                piranhaServiceBuilder.UseIdentityWithSeed<IdentitySQLServerDb>(options => options.UseSqlServer(configuration.GetConnectionString("PiranhaAuthConnection")));
            });
            //services.AddPiranhaApplication();
        }

        internal static void configuration(this IApi api)
        {
            // Initialize Piranha
            App.Init(api);

            // Configure cache level
            App.CacheLevel = CacheLevel.Full;

            // Build content types
            new PageTypeBuilder(api)
                .AddType(typeof(BlogArchive))
                .AddType(typeof(StandardPage))
                .AddType(typeof(HomePage))
                .Build()
                .DeleteOrphans();

            new PostTypeBuilder(api)
                .AddType(typeof(BlogPost))
                .Build()
                .DeleteOrphans();

            new SiteTypeBuilder(api)
                .AddType(typeof(BlogSite))
                .Build()
                .DeleteOrphans();
        }

        internal static void usePiranhaCms(this IApplicationBuilder app)
        {
            EditorConfig.FromFile("editorconfig.json");

            app.UsePiranha(options => 
            {
                options.UseManager();
                options.UseTinyMCE();
                options.UseIdentity();
            });

            // Piranha.App.Modules.Get<Piranha.Manager.Module>().Styles.Add("https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css");
        }
    }

}
