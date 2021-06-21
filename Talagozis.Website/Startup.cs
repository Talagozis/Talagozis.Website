using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Talagozis.AspNetCore.Extensions;
using Talagozis.Payments.Paypal;
using WebMarkupMin.AspNetCore5;
using System.Globalization;
using Microsoft.Extensions.Options;
using Talagozis.AspNetCore.Localization;
using Talagozis.Website.App_Plugins.Extensions;

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
            services.Configure<LanguageRouteConstraintOption>(this._configuration.GetSection(nameof(LanguageRouteConstraintOption)));
            services.AddLocalization("en", this._configuration.GetSection(nameof(LanguageRouteConstraintOption)));
            //services.AddLocalization(options => options.ResourcesPath = "Resources");

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

            services.addCmsServices(this._configuration);

            services.AddPaypalService(this._configuration.GetSection("Paypal"));

            services.AddWebMarkupMin(options => { options.DisablePoweredByHttpHeaders = true; }).AddHtmlMinification().AddHttpCompression();

            services.AddApplicationInsightsTelemetry();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApi api, ILogger<Startup> logger)
        {
            Directory.CreateDirectory(Path.Combine(env.ContentRootPath, @"../uploads"));

            app.UseExceptionHandlerLogger(ex => logger.LogError(ex, ex.Message));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
#if DEBUG
                app.UseDatabaseErrorPage();
#endif
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

                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + age.TotalSeconds.ToString("0", CultureInfo.InvariantCulture);
                }
            });
            app.UseWebMarkupMin();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.useCms(api);

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


}
