using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Piranha;
using Piranha.Models;
using Talagozis.Website.App_Plugins.Repositories;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
using Talagozis.Website.Models.Cv;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApi _api;
        private readonly ILogger<HomeController> _logger;
        private CultureInfo? _requestCulture;

        public HomeController(IApi api, ILogger<HomeController> logger) 
        {
            this._api = api;
            this._logger = logger;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            this._requestCulture = context.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture?.Culture ?? throw new InvalidOperationException($"The {nameof(CultureInfo)} for this request is not defined.");

            await base.OnActionExecutionAsync(context, next);
        }

        [HttpGet("index")]
        public Task<IActionResult> Index()
        {
            return this.HomePage();
        }

        [HttpGet("home")]
        public async Task<IActionResult> HomePage()
        {
            CVRepository cVRepository = new CVRepository();
            Person person = CVRepository.GetMyCV();

            IEnumerable<BlogArchive> allArchives = await this._api.Pages.GetAllAsync<BlogArchive>();
            allArchives = allArchives.Where(a => a.IsPublished).ToList();
            allArchives = allArchives.Where(a => a.ParentId.HasValue).ToList();
            allArchives = allArchives.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            ICollection<BlogArchive> postArchives = new List<BlogArchive>();
            foreach (BlogArchive blogArchive in allArchives)
            {
                CulturePage? culturePage = blogArchive.ParentId.HasValue ? await this._api.Pages.GetByIdAsync<CulturePage>(blogArchive.ParentId.Value) : null;

                if (culturePage != null && culturePage.Culture.Value.Id == this._requestCulture!.TwoLetterISOLanguageName)
                    postArchives.Add(blogArchive);
            }

            IEnumerable<BlogPost> allPosts = (await this._api.Posts.GetAllBySiteIdAsync<BlogPost>());
            allPosts = allPosts.Where(a => postArchives.Any(b => b.Id == a.BlogId));
            allPosts = allPosts.Where(a => a.IsPublished);

            HomePageViewModel homePageViewModel = new HomePageViewModel
            {
                Person = person,
                Archives = postArchives.Where(a => a.IsPublished).ToList(),
                LatestPosts = allPosts.ToList()
            };

			return this.View("~/Views/Home/HomePage.cshtml", homePageViewModel);
        }

        [HttpGet("blog")]
        public async Task<IActionResult> Blog()
        {
            ICollection<BlogArchive> allArchives = (await this._api.Pages.GetAllAsync<BlogArchive>()).ToList();
            allArchives = allArchives.Where(a => a.IsPublished).ToList();
            allArchives = allArchives.Where(a => a.ParentId.HasValue).ToList();
            allArchives = allArchives.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            ICollection<PostArchive<BlogPost>> postArchives = new List<PostArchive<BlogPost>>();
            foreach (BlogArchive blogArchive in allArchives)
            {
                CulturePage? culturePage = blogArchive.ParentId.HasValue ? await this._api.Pages.GetByIdAsync<CulturePage>(blogArchive.ParentId.Value) : null;

                if (culturePage != null && culturePage.Culture.Value.Id == this._requestCulture!.TwoLetterISOLanguageName)
                    postArchives.Add(await this._api.Archives.GetByIdAsync<BlogPost>(blogArchive.Id, null));
            }

            BlogViewModel blogViewModel = new BlogViewModel
            {
                Archives = allArchives.ToList(),
                PostArchives = postArchives.Where(a => a.Posts.Any(b => b.IsPublished)).ToList(),
            };

            return this.View("~/Views/Home/Blog.cshtml", blogViewModel);
        }

        [HttpGet("cv")]
        public IActionResult CV()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = CVRepository.GetMyCV();

            return this.View("~/Views/Home/CV.cshtml", person);
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ContactViewModel contactViewModel = new ContactViewModel();

            return this.View("~/Views/Home/Contact.cshtml", contactViewModel);
        }

        [HttpGet("getjson")]
        public Person getJson()
        {
            CVRepository cVRepository = new CVRepository();

            return CVRepository.GetMyCV();
        }

        [HttpGet("getPosts")]
        public async Task<IActionResult> getPosts()
        {
            IEnumerable<BlogPost> blogPosts = await this._api.Posts.GetAllBySiteIdAsync<BlogPost>();

            blogPosts = blogPosts.Where(a => a.IsPublished);

            return this.Ok(blogPosts.Select(a => new
            {
                a.Title,
                a.Permalink,
                Published = a.Published?.ToString("yyyy-MM-dd"),
                a.Heading?.SubTitle?.Value,
            }));
        }

        public IActionResult Error()
        {
            return this.View("~/Views/Shared/Error.cshtml");
        }

    }
}
