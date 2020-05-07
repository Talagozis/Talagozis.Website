using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using Piranha.AttributeBuilder;
using Piranha.Cache;
using Piranha.Manager.Editor;
using Talagozis.AspNetCore.Extensions;
using Talagozis.Payments.Paypal;
using WebMarkupMin.AspNetCore2;

namespace Talagozis.Website
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables();
            //this._configuration = builder.Build();
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Directory.CreateDirectory("../database");
            Directory.CreateDirectory("../uploads");

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<MvcOptions>(options =>
            {
                // options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddMvc().AddPiranhaManagerOptions().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddPiranha();
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage(Path.Combine(Directory.GetCurrentDirectory(), @"../uploads/"), "~/uploads/");
            services.AddPiranhaImageSharp();
            services.AddPiranhaManager();
            services.AddPiranhaTinyMCE();
            //services.AddMemoryCache();
            services.AddPiranhaMemoryCache();
            //services.AddOptions();

            services.AddPiranhaEF(options => options.UseSqlite("Filename=../database/piranha.blog.db"));
            services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options => options.UseSqlite("Filename=../database/piranha.blog.db"));

            services.AddPaypalService(this._configuration.GetSection("Paypal"));

            services.AddWebMarkupMin(options => { options.DisablePoweredByHttpHeaders = true; })
                .AddHtmlMinification()
                .AddHttpCompression();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApi api)
        {
            app.UseExceptionHandlerLogger(ex => Console.WriteLine(ex.Message));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                var options = new RewriteOptions().AddRedirectToHttps();
                app.UseRewriter(options);

                app.UseExceptionHandler("/Home/Error");
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
            app.UseAuthentication();

            api.configuration();
            app.usePiranhaCms();

            app.UseWebMarkupMin();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "areaRoute",
                //    template: "{area:exists}/{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" }
                //);

                routes.MapRoute(
                    name: "defaultHome",
                    template: "{action}",
                    defaults: new { controller = "Home", action = "Index" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}"
                );
            });
        }
    }

    internal static class PiranhaConfiguration
    {
        internal static void configuration(this IApi api)
        {
            // Initialize Piranha
            App.Init(api);

            // Configure cache level
            App.CacheLevel = CacheLevel.Full;

            // Build content types
            new PageTypeBuilder(api)
                .AddType(typeof(Models.BlogArchive))
                .AddType(typeof(Models.StandardPage))
                .AddType(typeof(Models.HomePage))
                .Build()
                .DeleteOrphans();

            new PostTypeBuilder(api)
                .AddType(typeof(Models.BlogPost))
                .Build()
                .DeleteOrphans();

            new SiteTypeBuilder(api)
                .AddType(typeof(Models.BlogSite))
                .Build()
                .DeleteOrphans();
        }

        internal static void usePiranhaCms(this IApplicationBuilder app)
        {
            app.UsePiranha();
            app.UsePiranhaManager();
            EditorConfig.FromFile("editorconfig.json");
            app.UsePiranhaTinyMCE();

            // Piranha.App.Modules.Get<Piranha.Manager.Module>().Styles.Add("https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css");
        }
    }

}
