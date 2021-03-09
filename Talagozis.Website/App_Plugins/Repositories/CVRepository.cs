using System;
using System.Collections.Generic;
using Talagozis.Website.Models.Cv;

namespace Talagozis.Website.App_Plugins.Repositories
{
    internal class CVRepository
    {
        //private static string TEST_TEXT = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
        private const string TEST_TEXT = "";


        public static Person GetMyCV() =>
            new Person
            {
                avatarPicturePath = "talagozis.jpg",
                css = "orbit-1.css",
                forename = "Christos",
                surname = "Talagozis",
                dob = new DateTime(1989, 10, 10),
                pob = "Serres, Greece",
                email = "christos@talagozis.com",
                gender = "Male",
                jobTitles = new string[] { "Software Engineer", "Fullstack Web Developer" },
                Address = new Address
                {
                    line = "10-12 Irodotou",
                    region = "Serres",
                    city = "Serres",
                    country = "Greece",
                    municipality = "Serres",
                    lat = 41.0865808m,
                    lon = 23.513035m,
                },
                maritalStatus = "Single",
                nationality = "Greek",
                phoneNumber = "+30 697 8348753",
                website = @"https://talagozis.com/",
                websiteBLog = @"https://talagozis.com/blog",
                linkedinLink = @"https://linkedin.com/in/talagozis/",
                githubLink = @"https://github.com/Talagozis",
                description = TEST_TEXT,
                educations = new List<Education>
                {
                    new Education
                    {
                        title = "Master of Science in Applied Informatics",
                        courseYears = 2,
                        description = TEST_TEXT,
                        graduationDate = new DateTime(2017, 5, 1),
                        university = "Technological Educational Institute of Central Macedonia, Greece",
                        thesisTitle =
                            "Parallel processing techniques for feature selection with the use of Feature Subset Selection algorithm",
                        mainCourses = new List<Course>
                        {
                            new Course {name = "Business Information Systems"},
                            new Course {name = "Statistical Analysis Tools"},
                            new Course {name = "Mobile Development"},
                            new Course {name = "Parallel and Distributed Programming"},
                            new Course {name = "Intelligence Systems"},
                            new Course {name = "Information and Network Security"},
                        },
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Evolutionary Computation",
                                description = "Best solution optimization using simulation of population evolution"
                            },
                            new Project {name = "RentMyHouse", description = "Online property booking platform"},
                        },
                    },
                    new Education
                    {
                        title = "Bachelor degree in Informatics Engineering",
                        courseYears = 4,
                        description = TEST_TEXT,
                        graduationDate = new DateTime(2014, 9, 1),
                        university = "Technological Educational Institute of Central Macedonia, Greece",
                        thesisTitle = "Development of parallel algorithms using MATLAB Parallel Computing Toolbox",
                        mainCourses = new List<Course>
                        {
                            new Course {name = "Object-Oriented Programming in C ++ and Java"},
                            new Course {name = "Visual Programming in C ++ and Java"},
                            new Course {name = "Computer Architecture"},
                            new Course {name = "Automatic Control System"},
                            new Course {name = "Algorithms and Data structures"},
                            new Course {name = "Operational Systems"},
                            new Course {name = "Web Development in PHP"},
                            new Course {name = "Evolutionary Computation"},
                            new Course {name = "Pattern Recognition"},
                            new Course {name = "Neural Networks"},
                        },
                        projects = new List<Project>
                        {
                            new Project {name = "Employee skills simulation software development using Java"}
                        },
                    },
                    new Education
                    {
                        title = "Bachelor degree in Computer Engineering",
                        courseYears = 4,
                        description = TEST_TEXT,
                        graduationDate = new DateTime(2012, 6, 1),
                        university = "Vilnius Gediminas Technical University, Lithuania",
                        mainCourses = new List<Course>
                        {
                            new Course {name = "Digital devices "},
                            new Course {name = "Computer Architecture "},
                            new Course {name = "Software Design "},
                            new Course {name = "Script Programming using Javascript"}
                        },
                        projects = new List<Project>(),
                    },
                },
                workExperience = new List<WorkExperience>
                {
                    new WorkExperience
                    {
                        position = "Platform Integrator",
                        companyName = "Interworks Cloud",
                        startDate = new DateTime(2019, 7, 1),
                        endDate = new DateTime(2020, 10, 1),
                        description = "Analyze, develop and test third party integrations with the core platform.",
                        typeOfBusiness = string.Empty,
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "GSuite integration",
                                typeOfBusiness = string.Empty,
                                description = "Two-way integration with GSuite platform.",
                                tags = new []{ ".NET Core", "ASP.NET", "C#", "ReactJs", "Typescript" }
                            },
                            new Project
                            {
                                name = "Acronis integration",
                                typeOfBusiness = string.Empty,
                                description = "Two-way integration with Acronis platform.",
                                tags = new []{ ".NET Core", "ASP.NET", "C#" }
                            },
                            new Project
                            {
                                name = "BitTitan integration",
                                typeOfBusiness = string.Empty,
                                description = "Two-way integration with BitTitan platform.",
                                tags = new []{ ".NET Core", "ASP.NET", "C#" }
                            }
                        }
                    },
                    new WorkExperience
                    {
                        companyName = "Freelancer",
                        position = "Full-Stack Software Developer",
                        startDate = new DateTime(2014, 10, 1),
                        endDate = null,
                        description = "Design, develop, test, publish and monitor application solutions using cool tools.",
                        typeOfBusiness = "Software development for business automation",
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "CNOP",
                                typeOfBusiness = "Stock marketplace",
                                startDate = new DateTime(2018, 6, 1),
                                endDate = new DateTime(2019, 1, 1),
                                description = "Stock market for shoes and live biding.",
                                links = new List<Link>
                                {
                                    new Link {value = "//cnop.com", isHidden = true},
                                },
                                tags = new[] { "ASP.NET Core", "AngularJs", "CouchDB", "AWS", "NodeJs" }
                            },
                            new Project
                            {
                                name = "MammasPizza",
                                typeOfBusiness = "Food delivery",
                                description = "Food ordering mobile app",
                                tags = new[] {"Ionic", "Angular", "Typescript" }
                            },
                            new Project
                            {
                                name = "HaciendaVerde",
                                typeOfBusiness = "Real estate booking",
                                description = "Online property booking web app",
                                tags = new[] {".NET Core", "ASP.NET Core" }
                            },
                            new Project
                            {
                                name = "Cloud Business",
                                typeOfBusiness = "Digital Invoicing",
                                description = "Cloud invoice management platform",
                                tags = new[] {"Python", "Django", "ReactJs.NET" }
                            },
                            new Project
                            {
                                name = "Logger",
                                description = "Software analytics service for tracking and monitoring",
                                tags = new[] {".NET", "ASP.NET MVC" }
                            },
                            new Project
                            {
                                name = "KTEL",
                                description = "Greece Buses Routes",
                                tags = new[] {".NET", "ASP.NET MVC", "UWP" }
                            },
                        },
                    },
                    new WorkExperience
                    {
                        companyName = "Dynamic Hellas Digital Works",
                        position = "Lead Developer",
                        startDate = new DateTime(2018, 9, 1),
                        endDate = new DateTime(2020, 1, 1),
                        description = "Architect the Video Academy platform upon Point-of-Purchase market strategy.",
                        typeOfBusiness = "Video Academy",
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Web Platform",
                                description = string.Empty,
                                tags = new []{".NET Core", "ASP.NET Core", "ReactJS.NET", "Azure" }
                            },
                            new Project
                            {
                                name = "Payment Portal",
                                description = string.Empty,
                                tags = new []{".NET Core", "ASP.NET Core", "ReactJS.NET", "Azure" }
                            },
                            new Project
                            {
                                name = "iOS mobile app",
                                description = string.Empty,
                                tags = new []{"Ionic", "Angular", "Typescript" }
                            },
                            new Project
                            {
                                name = "Android modible app",
                                description = string.Empty,
                                tags = new []{"Ionic", "Angular", "Typescript" }
                            },
                        },
                    },
                    new WorkExperience
                    {
                        companyName = "Nektar Kourtidis Bros S.A.",
                        position = "Lead Developer / Scrum Master",
                        startDate = new DateTime(2014, 8, 1),
                        endDate = null,
                        description = "Design and develop the Enterprise Resource Planning platform using microservices architecture and cloud computing",
                        typeOfBusiness = "Soft drinks producation",
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Production Management",
                                description = string.Empty,
                                tags = new []{".NET", "WinForms", "Cognitive services" }
                            },
                            new Project
                            {
                                name = "Analytics and Insights",
                                description = string.Empty,
                                tags = new []{".NET", "ASP.NET MVC", "Azure"}
                            },
                            new Project
                            {
                                name = "CRM and Sale Predictions",
                                description = string.Empty,
                                tags = new []{".NET", "WinForms", "Cognitive services" }
                            },
                            new Project
                            {
                                name = "Fridges Management",
                                description = string.Empty,
                                tags = new []{".NET", "WinForms"}
                            },
                            new Project
                            {
                                name = "Assets Management",
                                description = string.Empty,
                                tags = new []{".NET", "WinForms"}
                            },
                        },
                    },
                    new WorkExperience
                    {
                        position = "Full-Stack Software Developer",
                        companyName = "Serres Delivery",
                        startDate = new DateTime(2016, 5, 1),
                        endDate = null,
                        description = "Design, develop, test, publish and monitor Amvrosia platform using amazing technologies.",
                        typeOfBusiness = "Online food delivery platform",
                        links = new List<Link>
                        {
                            new Link {value = "//serresdelivery.gr", isHidden = true},
                        },
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Web Platform",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{".NET", "ASP.NET MVC", "ReactJs.NET", "Azure" }
                            },
                            new Project
                            {
                                name = "Web Api",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{".NET", "ASP.NET MVC", "SignalR", "Azure" }
                            },
                            new Project
                            {
                                name = "Payment Portal",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{ "NodeJs", "Typescript", "ReactJs", "Azure" }
                            },
                            new Project
                            {
                                name = "Desktop Application",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{".NET", "WPF", "SignalR" }
                            },
                            new Project
                            {
                                name = "Progressive Web App",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{"Ionic", "Angular", "Typescript", "Azure" }
                            },
                            new Project
                            {
                                name = "Android Modible App",
                                typeOfBusiness = "Amvrosia",
                                description = string.Empty,
                                tags = new []{ "Ionic", "Angular", "Typescript", "Java"}
                            },
                        },
                    },
                    new WorkExperience
                    {
                        position = "Machine Learning Engineer",
                        companyName = "StarBet",
                        startDate = new DateTime(2018, 3, 1),
                        endDate = new DateTime(2020, 9, 1),
                        description = "Design and develop binomial regression and classification algorithm.",
                        typeOfBusiness = string.Empty,
                        links = new List<Link>
                        {
                            new Link { value = "//starbet.gr", isHidden = true },
                        },
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Recurrent Deep Conversion",
                                typeOfBusiness = "Betting foresight",
                                description = "Anomaly detection and score predictions on international football matches.",
                                tags = new []{ "C#", "F#", ".NET Core", "ML.NET", "TensorFlow", },
                            }
                        }
                    },
                    new WorkExperience
                    {
                        position = "Full-Stack Web Developer",
                        companyName = "BlumenRiviera",
                        startDate = new DateTime(2013, 10, 1),
                        endDate = new DateTime(2014, 8, 1),
                        description = "Design, develop and test web applications.",
                        typeOfBusiness = "Software development for vacation booking",
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "BlumenRiviera.com",
                                typeOfBusiness = "Real estate booking",
                                description = "Online property booking platform.",
                                tags = new []{"Java", "Velocity", "PHP"}
                            },
                            new Project
                            {
                                name = "SyncUBooking",
                                typeOfBusiness = "Services integrations",
                                description = "Online property booking synchronization engine.",
                                tags = new []{"Java", "JSP", "Javascript"}
                            },
                        },
                    },
                    new WorkExperience
                    {
                        position = "Desktop Developer",
                        companyName = "Serres Computer Software",
                        startDate = new DateTime(2012, 11, 1),
                        endDate = new DateTime(2013, 9, 1),
                        description = "Design, develop and delivery software solutions.",
                        typeOfBusiness = "",
                        projects = new List<Project>
                        {
                            new Project
                            {
                                name = "Gym Manager",
                                description = "Gym and boxes management application",
                                tags = new[] { "Java", "FX" }
                            },
                            new Project
                            {
                                name = "Invoice Manager",
                                description = "Digital invoicing management application",
                                tags = new[] {"Java", "FX"}
                            },
                            new Project
                            {
                                name = "Protocol",
                                description = "Protocol management application",
                                tags = new[] {".NET", "WinForms"}
                            },
                            new Project
                            {
                                name = "Storehouse",
                                description = "Warehouse management application",
                                tags = new[] {".NET", "WinForms"}
                            },
                            new Project
                            {
                                name = "Land registry",
                                description = "Land registry service platform",
                                tags = new[] {".NET", "WinForms"}
                            },
                        },
                    },
                },
                researchExperience = new List<ResearchExperience>
                {
                    new ResearchExperience
                    {
                        title = "k-Means algorithm",
                        organizationName = "Technological Educational Institute of Central Macedonia, Greece",
                        link = string.Empty,
                        tutorNames = new[] {"Varsamis D."},
                        startDate = new DateTime(2016, 7, 12),
                        endDate = null,
                        description = "Research and develop algorithms for data clustering using Matlab tools and Python.",
                        publicationLink =
                            @"https://waset.org/publications/10008128/a-parallel-implementation-of-k-means-in-matlab",
                    },
                    new ResearchExperience
                    {
                        title = "Feature Subset Selection algorithm",
                        organizationName = "Technological Educational Institute of Central Macedonia, Greece",
                        link = string.Empty,
                        tutorNames = new[] {"Varsamis D."},
                        startDate = new DateTime(2016, 12, 12),
                        endDate = null,
                        description =
                            "Research and develop algorithms for information classification using Matlab tools and Python.",

                    },
                    new ResearchExperience
                    {
                        title = "Parallel processing optimization techniques",
                        organizationName = "Technological Educational Institute of Central Macedonia, Greece",
                        link = string.Empty,
                        tutorNames = new[] {"Varsamis D."},
                        startDate = new DateTime(2012, 11, 18),
                        endDate = new DateTime(2016, 7, 1),
                        description =
                            "Develop algorithms for information classification optimization through parallel processing.",
                        publicationLink =
                            @"https://pdfs.semanticscholar.org/9aab/9d4d1213051ff3b7ea5aab8a5dd41e18f7e6.pdf?_ga=2.12012215.2026984106.1559296832-1893411076.1559296832",
                    },
                },
                openSourceContributions = new List<OpenSourceContribution>
                {
                    new OpenSourceContribution
                    {
                        name = "Food-Order",
                        repository = "Talagozis/Food-Order",
                        source = OpenSourceContribution.Source.GitHub,
                        description = string.Empty,
                        link = new Link { value = @"https://github.com/Talagozis/Food-Order", isHidden = false }
                    },
                    new OpenSourceContribution
                    {
                        name = "Intent Analysis",
                        repository = "Talagozis/IntentAnalysis",
                        source = OpenSourceContribution.Source.GitHub,
                        description = string.Empty,
                        link = new Link { value = @"https://github.com/Talagozis/IntentAnalysis", isHidden = false }
                    },
                    new OpenSourceContribution
                    {
                        name = "Evolutionary Computation",
                        repository = "Talagozis/EvolutionaryComputation",
                        source = OpenSourceContribution.Source.GitHub,
                        description = string.Empty,
                        link = new Link { value = @"https://github.com/Talagozis/EvolutionaryComputation", isHidden = false }
                    },
                    new OpenSourceContribution
                    {
                        name = "Codility Lessons",
                        repository = "Talagozis/Codility-Lessons",
                        source = OpenSourceContribution.Source.GitHub,
                        description = string.Empty,
                        link = new Link { value = @"https://github.com/Talagozis/Codility-Lessons", isHidden = false }
                    },
                    new OpenSourceContribution
                    {
                        name = "ColorizeCss",
                        repository = "Talagozis/ColorizeCss",
                        source = OpenSourceContribution.Source.GitHub,
                        description = string.Empty,
                        link = new Link { value = @"https://github.com/Talagozis/ColorizeCss", isHidden = false }
                    },
                },
                awards = new List<Awards>
                {
                    new Awards
                    {
                        title = "2nd place at Hackathon 1.0",
                        issuer = "SerresTech & Technological Educational Institute of Central Macedonia",
                        issueDate = new DateTime(2016, 4, 17),
                        description = string.Empty,
                        link = string.Empty,
                    },
                },
                coreSkills = new List<CoreSkill>(),
                interests = new List<Interest>(),
                portfolios = new List<Portfolio>(),
            };
    }
}