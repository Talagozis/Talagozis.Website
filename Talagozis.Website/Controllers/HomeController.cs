using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Talagozis.Website.Models.Cv;

namespace Talagozis.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.HomePage();
        }

        public IActionResult HomePage()
        {
            CVRepository cVRepository = new CVRepository();

            Person person = cVRepository.GetMyCV();

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
