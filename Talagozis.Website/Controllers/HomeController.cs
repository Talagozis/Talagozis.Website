using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Piranha;
using Talagozis.Website.App_Plugins.Repositories;
using Talagozis.Website.Models;
using Talagozis.Website.Models.Cv;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApi _api;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IApi api, ILogger<HomeController> logger) 
        {
            this._api = api;
            this._logger = logger;
        }
        
        public Task<IActionResult> Index()
        {
            return this.HomePage();
        }

        public async Task<IActionResult> HomePage()
        {
            CVRepository cVRepository = new CVRepository();
            Person person = cVRepository.GetMyCV();

            IEnumerable<BlogArchive> allArchives = await this._api.Pages.GetAllAsync<BlogArchive>();
            allArchives = allArchives.Where(a => a.Published.HasValue).ToList();
            allArchives = allArchives.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            IEnumerable<BlogPost> allPosts = (await this._api.Posts.GetAllBySiteIdAsync<BlogPost>()).Where(a => allArchives.Any(b => b.Id == a.BlogId));

            HomePageViewModel homePageViewModel = new HomePageViewModel
            {
                Person = person,
                Archives = allArchives.ToList(),
                LatestPosts = allPosts.ToList()
            };

			return this.View("~/Views/Home/HomePage.cshtml", homePageViewModel);
        }

        public async Task<IActionResult> Blog()
        {
            IEnumerable<BlogArchive> allArchives = await this._api.Pages.GetAllAsync<BlogArchive>();
            allArchives = allArchives.Where(a => a.Published.HasValue).ToList();
            allArchives = allArchives.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            foreach (var blogArchive in allArchives)
            {
                blogArchive.Archive = await this._api.Archives.GetByIdAsync(blogArchive.Id, null, null, null, null, null);
            }

            BlogViewModel blogViewModel = new BlogViewModel
            {
                Archives = allArchives.ToList()
            };

            return this.View("~/Views/Home/Blog.cshtml", blogViewModel);
        }

        public IActionResult CV()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            return this.View("~/Views/Home/CV.cshtml", person);
        }

        public IActionResult Contact()
        {
            ContactViewModel contactViewModel = new ContactViewModel();

            return this.View("~/Views/Home/Contact.cshtml", contactViewModel);
        }

        public Person getJson()
        {
            CVRepository cVRepository = new CVRepository();

            return cVRepository.GetMyCV();
        }

        public IActionResult Error()
        {
            return this.View("~/Views/Shared/Error.cshtml");
        }

    }
}
