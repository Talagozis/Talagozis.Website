using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Talagozis.Website.Models;
using Talagozis.Website.Models.Cv;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApi _api;

        public HomeController(IApi api) 
        {
            _api = api;
        }
        
        public IActionResult Index()
        {
            return this.HomePage();
        }

        public IActionResult HomePage()
        {
            CVRepository cVRepository = new CVRepository();
            Person person = cVRepository.GetMyCV();

            var allPosts = _api.Posts.GetAll<BlogPost>().Where(a => _api.Archives.GetById<BlogArchive>(a.BlogId, 1, null, null, null).Published.HasValue);

            List<BlogArchive> archives = _api.Posts.GetAll<BlogPost>().Select(a => _api.Archives.GetById<BlogArchive>(a.BlogId, 1, null, null, null)).ToList();
            archives = archives.Where(a => a.Published.HasValue).ToList();
            archives = archives.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            HomePageViewModel homePageViewModel = new HomePageViewModel
            {
                Person = person,
                Archives = archives,
                LatestPosts = allPosts.ToList()
            };

			return View("~/Views/Home/HomePage.cshtml", homePageViewModel);
        }

        public IActionResult Blog()
        {
            var csharpArchiveId = new Guid("f6682da4-11f4-40b4-b118-470bcc198613");
            var javaArchiveId = new Guid("e8ed04db-e33b-46fe-97d7-e0e025a269e2");
            var javascriptArchiveId = new Guid("9a82888a-03ee-4522-950a-6407adf7f413");
            var machineLearningArchiveId = new Guid("f1891e6d-1efc-4795-8759-133bb977c9e4");
            var ionicArchiveId = new Guid("d3f5e1a5-7f27-4fe9-b033-4a817745694d");
            var flutterArchiveId = new Guid("09b2c5b9-21ac-4ffe-8413-5bc0256b7756");
            var reactJsArchiveId = new Guid("6e23dca6-c9ae-4560-af54-ffffea6edefd");
            var aspNetCoreArchiveId = new Guid("bdfcd253-fd56-4554-8b81-94de6a3dea83");
            var dotnetArchiveId = new Guid("e03275f2-e5d7-4be8-a9ee-88a8136109ff");
            var lifeOfProgrammerArchiveId = new Guid("a1d84800-7ba6-4444-87f2-5c909942d75f");

            var archives = new List<BlogArchive>
            {
                _api.Archives.GetById<BlogArchive>(csharpArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(javaArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(javascriptArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(machineLearningArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(ionicArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(flutterArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(reactJsArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(aspNetCoreArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(dotnetArchiveId, 1, null, null, null),
                _api.Archives.GetById<BlogArchive>(lifeOfProgrammerArchiveId, 1, null, null, null),
            }.Where(a => a.Published.HasValue).OrderByDescending(a => a.Archive.Posts.Max(b => b.Published)).ToList();

            BlogViewModel blogViewModel = new BlogViewModel
            {
                Archives = archives,
                Categories = archives.SelectMany(a => _api.Categories.GetAll(a.Id)).ToList(),
                Tags = archives.SelectMany(a => _api.Tags.GetAll(a.Id)).ToList(),
            };

            return View("~/Views/Home/Blog.cshtml", blogViewModel);
        }

        public IActionResult CV()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            return View("~/Views/Home/CV.cshtml", person);
        }

        public IActionResult Contact()
        {
            ContactViewModel contactViewModel = new ContactViewModel();

            return View("~/Views/Home/Contact.cshtml", contactViewModel);
        }

        public Person getJson()
        {
            CVRepository cVRepository = new CVRepository();

            return cVRepository.GetMyCV();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
