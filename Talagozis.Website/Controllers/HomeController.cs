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
        public IActionResult Index(Guid blogId)
        {
            return this.HomePage(blogId);
        }

        public IActionResult HomePage(Guid Id)
        {
            Id = new Guid("f6682da4-11f4-40b4-b118-470bcc198613");

            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

            ViewBag.Id = Id;
            ViewBag.latestPosts = _api.Posts.GetAll<Models.BlogPost>(Id).ToList();

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
