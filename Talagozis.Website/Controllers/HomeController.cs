using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            //ViewBag.pod = await Talagozis.Web.Services.Bing.getPictureOfTheDay();

			return View("~/Views/Home/HomePage.cshtml", person);
        }

        
        public IActionResult Blog()
        {
            var csharpArchiveId = new Guid("f6682da4-11f4-40b4-b118-470bcc198613");
            var javaArchiveId = new Guid("e8ed04db-e33b-46fe-97d7-e0e025a269e2");
            var machineLearningArchiveId = new Guid("f1891e6d-1efc-4795-8759-133bb977c9e4");
            var ionicArchiveId = new Guid("d3f5e1a5-7f27-4fe9-b033-4a817745694d");
            var flutterArchiveId = new Guid("09b2c5b9-21ac-4ffe-8413-5bc0256b7756");
            var reactJsArchiveId = new Guid("6e23dca6-c9ae-4560-af54-ffffea6edefd");
            var aspNetCoreArchiveId = new Guid("bdfcd253-fd56-4554-8b81-94de6a3dea83");

            // var csharpPosts = _api.Posts.GetAll<Models.BlogPost>(csharpArchiveId).ToList();
            // var javaPosts = _api.Posts.GetAll<Models.BlogPost>(javaArchiveId).ToList();
			var archives = new List<Models.BlogArchive>
            { 
                _api.Archives.GetById<Models.BlogArchive>(csharpArchiveId, 1, null, null, null), 
                _api.Archives.GetById<Models.BlogArchive>(javaArchiveId, 1, null, null, null),
                _api.Archives.GetById<Models.BlogArchive>(machineLearningArchiveId, 1, null, null, null),
                _api.Archives.GetById<Models.BlogArchive>(ionicArchiveId, 1, null, null, null),
                _api.Archives.GetById<Models.BlogArchive>(flutterArchiveId, 1, null, null, null),
                _api.Archives.GetById<Models.BlogArchive>(reactJsArchiveId, 1, null, null, null),
                _api.Archives.GetById<Models.BlogArchive>(aspNetCoreArchiveId, 1, null, null, null),
            };

			// ViewBag.latestPosts = csharpPosts.Concat(javaPosts);
			ViewBag.archives = archives;

			return View("~/Views/Home/Blog.cshtml", archives);
        }


        public IActionResult CV()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            return View("~/Views/Home/CV.cshtml", person);
        }

        public IActionResult Contact()
        {
            return View("~/Views/Home/Contact.cshtml");
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
