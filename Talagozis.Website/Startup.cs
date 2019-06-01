using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Talagozis.AspNetCore.Services.Paypal;
using WebMarkupMin.AspNetCore2;

namespace Talagozis.Website
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Directory.CreateDirectory("../database");
            Directory.CreateDirectory("../uploads");
            Directory.CreateDirectory("../logs");

            services.Configure<MvcOptions>(options =>
            {
                // options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddMvc(config =>
            {
                config.ModelBinderProviders.Insert(0, new Piranha.Manager.Binders.AbstractModelBinderProvider());
            });
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage(Path.Combine(Directory.GetCurrentDirectory(), @"../uploads/"), "~/uploads/");
            services.AddPiranhaImageSharp();            
            services.AddPiranhaEF(options => options.UseSqlite("Filename=../database/piranha.blog.db"));
            services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options => options.UseSqlite("Filename=../database/piranha.blog.db"));
            services.AddPiranhaManager();
            services.AddSingleton<ICache, Piranha.Cache.MemCache>();

            //services.AddOptions();

            services.AddPaypal(Configuration.GetSection("Paypal"));

            services.AddWebMarkupMin(options => { options.DisablePoweredByHttpHeaders = true; })
                    .AddHttpCompression();


            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider services)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                var options = new RewriteOptions().AddRedirectToHttps();
                app.UseRewriter(options);

                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
            }

            // Initialize Piranha
            var api = services.GetService<IApi>();
            App.Init();

            // Configure cache level
            App.CacheLevel = Piranha.Cache.CacheLevel.None;

            // Build content types
            var pageTypeBuilder = new Piranha.AttributeBuilder.PageTypeBuilder(api)
                .AddType(typeof(Models.BlogArchive))
                .AddType(typeof(Models.StandardPage))
				.AddType(typeof(Models.HomePage))
				.Build()
                .DeleteOrphans();

            var postTypeBuilder = new Piranha.AttributeBuilder.PostTypeBuilder(api)
                .AddType(typeof(Models.BlogPost))
                .Build()
                .DeleteOrphans();

            var siteTypeBuilder = new Piranha.AttributeBuilder.SiteTypeBuilder(api)
                .AddType(typeof(Models.BlogSite))
                .Build()
                .DeleteOrphans();


            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"../uploads")),
                RequestPath = new PathString("/uploads")
            });
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UsePiranha();
            app.UsePiranhaManager();

            // Piranha.App.Modules.Get<Piranha.Manager.Module>().Styles.Add("https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css");

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
}
