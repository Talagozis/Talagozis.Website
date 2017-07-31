﻿using System;
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
            string TEST_TEXT = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";


            Person person = new Person
            {
                forename = "Christos",
                surname = "Talagozis",
                dob = new DateTime(1989, 10, 10),
                pob = "Serres, Greece",
                email = "christos@talagozis.com",
                gender = "Male",
                jobTitles = new string[] { "Backend Web Developer", "Desktop Developer" },
                linkedinLink = @"https://www.linkedin.com/in/talagozis/",
                githubLink = @"https://github.com/Talagozis",
                educations = new List<Education>
                {
                    new Education
                    {
                        title = "Master of Science in Applied Informatics",
                        courseYears = 2,
                        description = TEST_TEXT,
                        graduationDate = new DateTime(2017, 5, 1),
                        university = "Technological Educational Institute of Central Macedonia, Greece",
                    },
                    new Education
                    {
                        title = "Bachelor degree in Informatics Engineering",
                        courseYears = 4,
                        description = TEST_TEXT,
                        graduationDate = new DateTime(2014, 9, 1),
                        university = "Technological Educational Institute of Central Macedonia, Greece",
                    },
                },
                workingExperience = new List<WorkingExperience>
                {
                    new WorkingExperience
                    {
                        position = "Full-Stack Software Developer",
                        companyName = "Freelancer",
                        startDate = new DateTime(2014, 10, 1),
                        endDate = null,
                        description = "Design, develop, test, publish and monitor desktop and web applications in .NET",
                        project = "",
                        typeOfBusiness = "Software development for business automation"
                    },
                    new WorkingExperience
                    {
                        position = "Full-Stack Web Developer",
                        companyName = "BlumenRiviera",
                        startDate = new DateTime(2013, 10, 1),
                        endDate = new DateTime(2014, 8, 1),
                        description = "Design, develop and test web applications in Java, Velocity and PHP",
                        project = "",
                        typeOfBusiness = "Software development for vacation booking",
                    },
                    new WorkingExperience
                    {
                        position = "Desktop Developer",
                        companyName = "Serres Computer Software",
                        startDate = new DateTime(2012, 11, 1),
                        endDate = new DateTime(2013, 5, 1),
                        description = "Design and develop software with .NET, Test software, Publish and reporting",
                        project = "",
                        typeOfBusiness = "",
                    },
                },
        };


            return View("~/Views/Home/CV.cshtml", person);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
