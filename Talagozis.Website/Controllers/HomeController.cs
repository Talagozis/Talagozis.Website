using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Talagozis.Website.Models;

namespace Talagozis.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.CV();
        }

        public IActionResult CV()
        {
            Person person = new Person
            {
                forename = "Christos",
                surname = "Talagozis",
                dob = new DateTime(1989, 10, 10),
                pob = "Serres, Greece",
                email = "christos@talagozis.com",
                gender = "Male",
                jobTitles = new string[] { "Backend Web Developer", "Desktop Developer" },
                linkedinLink = "https://www.linkedin.com/in/talagozis/"
        };


            return View("~/Views/Home/CV.cshtml", person);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
