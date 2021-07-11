using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Piranha.AspNetCore.Identity.SQLServer;
using Piranha.AttributeBuilder;
using Piranha.Cache;
using Piranha.Data.EF.SQLServer;
using Piranha.Manager.Editor;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
using Talagozis.Website.Models.Cms.SiteTypes;

namespace Talagozis.Website.App_Plugins.Extensions
{
	internal static class PiranhaExtensions
	{
		internal static IServiceCollection addCmsServices(this IServiceCollection services, IConfiguration configuration)
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

			return services;
		}

		internal static IApplicationBuilder useCms(this IApplicationBuilder app, IApi api)
        {
            // Initialize Piranha
            App.Init(api);

            // Configure cache level
            App.CacheLevel = CacheLevel.Full;

            // Build content types
            new ContentTypeBuilder(api)
                .AddType(typeof(BlogArchive))
                //.AddType(typeof(StandardPage))
                .AddType(typeof(CulturePage))
                .AddType(typeof(HomePage))
                .AddType(typeof(BlogPost))
                .AddType(typeof(BlogSite))
                .Build()
                .DeleteOrphans();

            EditorConfig.FromFile("editorconfig.json");

            app.UsePiranha(options =>
            {
                options.UseManager();
                options.UseTinyMCE();
                options.UseIdentity();
            });

			// Piranha.App.Modules.Get<Piranha.Manager.Module>().Styles.Add("https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css");

			return app;
		}
	}


}
