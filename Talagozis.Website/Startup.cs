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
            services.Configure<MvcOptions>(options =>
            {
                // options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddMvc(config =>
            {
                config.ModelBinderProviders.Insert(0, new Piranha.Manager.Binders.AbstractModelBinderProvider());
            });
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage();
            services.AddPiranhaImageSharp();
            services.AddPiranhaEF(options => options.UseSqlite("Filename=./piranha.blog.db"));
            services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options => options.UseSqlite("Filename=./piranha.blog.db"));
            services.AddPiranhaManager();
            services.AddSingleton<ICache, Piranha.Cache.MemCache>();

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
            App.Init(api);

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


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UsePiranha();
            app.UsePiranhaManager();

            // Piranha.App.Modules.Get<Piranha.Manager.Module>().Styles.Add("https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );

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
