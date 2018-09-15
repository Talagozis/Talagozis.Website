using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Talagozis.Website.Models.Cv;

namespace Talagozis.Website.Controllers
{
    public class HomeController : Controller
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
            var csharpArchiveId = new Guid("f6682da4-11f4-40b4-b118-470bcc198613");
            var javaArchiveId = new Guid("e8ed04db-e33b-46fe-97d7-e0e025a269e2");

            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            var csharpPosts = _api.Posts.GetAll<Models.BlogPost>(csharpArchiveId).ToList();
            var javaPosts = _api.Posts.GetAll<Models.BlogPost>(javaArchiveId).ToList();
			var archives = new List<Models.BlogArchive> 
            { 
                _api.Archives.GetById<Models.BlogArchive>(csharpArchiveId, 1, null, null, null), 
                _api.Archives.GetById<Models.BlogArchive>(javaArchiveId, 1, null, null, null), 
            };

			ViewBag.latestPosts = csharpPosts.Concat(javaPosts);
			ViewBag.archives = archives;

			return View("~/Views/Home/HomePage.cshtml", person);
        }

        public IActionResult CV()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            return View("~/Views/Home/CV.cshtml", person);
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
