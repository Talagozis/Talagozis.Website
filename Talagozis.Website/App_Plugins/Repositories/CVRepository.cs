using System;
using System.Collections.Generic;
using Talagozis.Website.Models.Cv;

internal class CVRepository
{
    public Person GetMyCV()
    {

        string TEST_TEXT = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
        TEST_TEXT = string.Empty;

        Person person = new Person
        {
            forename = "Christos",
            surname = "Talagozis",
            dob = new DateTime(1989, 10, 10),
            pob = "Serres, Greece",
            email = "christos@talagozis.com",
            gender = "Male",
            jobTitles = new string[] { "Fullstack Web Developer", "Software Engineer" },
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
            linkedinLink = @"https://www.linkedin.com/in/talagozis/",
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
                    thesisTitle = "Parallel processing techniques for feature selection with the use of Feature Subset Selection algorithm",
                    mainCourses = new List<Course>
                    {
                        new Course { name = "Business Information Systems"},
                        new Course { name = "Statistical Analysis Tools"},
                        new Course { name = "Mobile Development"},
                        new Course { name = "Parallel and Distributed Programming"},
                        new Course { name = "Intelligence Systems"},
                        new Course { name = "Information and Network Security"},
                    },
                    projects = new List<Project>
                    {
                        new Project { name = "Evolutionary Computation", description = "Best solution optimization using simulation of population evolution"},
                        new Project { name = "RentMyHouse", description = "Online property booking platform"},
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
                        new Course { name = "Object-Oriented Programming in C ++ and Java"},
                        new Course { name = "Visual Programming in C ++ and Java"},
                        new Course { name = "Computer Architecture"},
                        new Course { name = "Automatic Control System"},
                        new Course { name = "Algorithms and Data structures"},
                        new Course { name = "Operational Systems"},
                        new Course { name = "Web Development in PHP"},
                        new Course { name = "Evolutionary Computation"},
                        new Course { name = "Pattern Recognition"},
                        new Course { name = "Neural Networks"},
                    },
                    projects = new List<Project>
                    {
                        new Project { name = "Employee skills simulation software development using Java" }
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
                        new Course { name = "Digital devices "},
                        new Course { name = "Computer Architecture "},
                        new Course { name = "Software Design "},
                        new Course { name = "  Script Programming using Javascript"}
                    },
                    projects = new List<Project>(),
                },
            },
            workExperience = new List<WorkExperience>
            {
                new WorkExperience
                {
                    companyName = "Freelancer",
                    position = "Full-Stack Software Developer",
                    startDate = new DateTime(2014, 10, 1),
                    endDate = null,
                    description = "Design, develop, test, publish and monitor desktop and web applications in .NET, Django, ReactJs, Ionic and many other cool frameworks.",
                    typeOfBusiness = "Software development for business automation",
                    projects = new List<Project>
                    {
                        //new Project { name = "HaciendaVerde", description = "Real estate booking" },
                        new Project { name = "Cloud Business", description = "Cloud invoice management platform" },
                        new Project { name = "Logger", description = "Software analytics service for tracking and monitoring" },
                        new Project { name = "KTEL", description = "Greece Buses Routes" },
                        new Project { name = "Protocol", description = "Protocol management application" },
                        new Project { name = "Storehouse", description = "Warehouse management application" },
                        new Project { name = "Land registry", description = "Land registry service platform" },
                    },
                },
                new WorkExperience
                {
                    companyName = "Nektar Kourtidis Bros S.A.",
                    position = "Chief Technology Officer",
                    startDate = new DateTime(2014, 8, 1),
                    endDate = null,
                    description = "Design and develop the Enterprise Resource Planning platform using microservices architecture in .NET, Azure, Cognitive services and much more.",
                    typeOfBusiness = "Soft drinks producation",
                    projects = new List<Project>
                    {
                        new Project { name = "Production Management", description = TEST_TEXT },
                        new Project { name = "Analytics and Insights", description = TEST_TEXT },
                        new Project { name = "CRM and Sale Predictions", description = TEST_TEXT },
                        new Project { name = "Fridges Management", description = TEST_TEXT },
                    },
                },
                new WorkExperience
                {
                    position = "Full-Stack Software Developer",
                    companyName = "Serres Delivery",
                    startDate = new DateTime(2016, 5, 1),
                    endDate = null,
                    description = "Design, develop, test, publish and monitor Amvrosia platform using ASP.NET, ReactJs, SignalR, WPF, Azure and many other amazing technologies.",
                    typeOfBusiness = "Online food delivery platform",
                    link = "//serresdelivery.gr",
                    projects = new List<Project>
                    {
                        new Project { name = "Amvrosia Web Platform", description = TEST_TEXT },
                        new Project { name = "Amvrosia Web Api", description = TEST_TEXT },
                        new Project { name = "Amvrosia Payment Portal", description = TEST_TEXT },
                        new Project { name = "Amvrosia Desktop Application", description = TEST_TEXT },
                    },
                },
                new WorkExperience
                {
                    position = "Full-Stack Software Developer",
                    companyName = "CNOP",
                    startDate = new DateTime(2018, 6, 1),
                    endDate = new DateTime(2019, 1, 1),
                    description = "Develop software and operations for CNOP platform using ASP.NET Core, AngularJs and CouchDB on AWS.",
                    typeOfBusiness = "Stock market for shoes",
                    link = "//cnop.com",
                },
                new WorkExperience
                {
                    position = "Machine Learning Engineer",
                    companyName = "StarBet",
                    startDate = new DateTime(2018, 3, 1),
                    endDate = null,
                    description = "Design and develop binomial regression and classification software on big data using F#, ML.NET and TensorFlow.",
                    typeOfBusiness = "Anomaly detection and score predictions on international football matches.",
                    link = "//starbet.gr",
                },
                new WorkExperience
                {
                    position = "Full-Stack Web Developer",
                    companyName = "BlumenRiviera",
                    startDate = new DateTime(2013, 10, 1),
                    endDate = new DateTime(2014, 8, 1),
                    description = "Design, develop and test web applications in Java, Velocity and PHP",
                    typeOfBusiness = "Software development for vacation booking",
                    projects = new List<Project>
                    {
                        new Project { name = "BlumenRiviera.com", description = "Online property booking." },
                        new Project { name = "SyncUBooking", description = "Online property booking synchronization." },
                    },
                },
                new WorkExperience
                {
                    position = "Desktop Developer",
                    companyName = "Serres Computer Software",
                    startDate = new DateTime(2012, 11, 1),
                    endDate = new DateTime(2013, 5, 1),
                    description = "Design and develop software with .NET and Java.",
                    typeOfBusiness = "",
                    projects = new List<Project>
                    {
                        new Project { name = "Gym Manager", description = TEST_TEXT },
                        new Project { name = "Invoice Manager", description = TEST_TEXT },
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
                    tutorNames = new [] { "Varsamis D." },
                    startDate = new DateTime(2016, 7, 12),
                    endDate = null,
                    description = "Research and develop algorithms for data clustering using Matlab tools and Python.",

                },
                new ResearchExperience
                {
                    title = "Feature Subset Selection algorithm",
                    organizationName = "Technological Educational Institute of Central Macedonia, Greece",
                    link = string.Empty,
                    tutorNames = new [] { "Varsamis D." },
                    startDate = new DateTime(2016, 12, 12),
                    endDate = null,
                    description = "Research and develop algorithms for information classification using Matlab tools and Python.",

                },
                new ResearchExperience
                {
                    title = "Parallel processing optimization techniques",
                    organizationName = "Technological Educational Institute of Central Macedonia, Greece",
                    link = string.Empty,
                    tutorNames = new [] { "Varsamis D." },
                    startDate = new DateTime(2012, 11, 18),
                    endDate = new DateTime(2016, 7, 1),
                    description = "Develop algorithms for information classification optimization through parallel processing.",

                },
            },
            awards = new List<Awards>
            {
                new Awards
                {
                    title  = "2nd place at Hackathon 1.0",
                    issuer = "SerresTech & Technological Educational Institute of Central Macedonia",
                    issueDate = new DateTime(2016, 4, 17),
                    description = string.Empty,
                    link = string.Empty,
                },
            },
            skills = new List<Skill> { },
            interests = new List<Interest> { },
            portfolios = new List<Portfolio> { },

        };


        return person;
    }


}