using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Linq;
using Talagozis.Website.Models;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class CmsController : Controller
    {
        private readonly IApi _api;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public CmsController(IApi api) 
        {
            _api = api;
        }


        /// <summary>
        /// Gets the blog archive with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="year">The optional year</param>
        /// <param name="month">The optional month</param>
        /// <param name="page">The optional page</param>
        /// <param name="category">The optional category</param>
        /// <param name="tag">The optional tag</param>
        [Route("archive")]
        public IActionResult Archive(Guid id, int? year = null, int? month = null, int? page = null, Guid? category = null, Guid? tag = null) 
        {
            Models.BlogArchive model;

            if (category.HasValue)
                model = _api.Archives.GetByCategoryId<Models.BlogArchive>(id, category.Value, page, year, month);
            else if (tag.HasValue)
                model = _api.Archives.GetByTagId<Models.BlogArchive>(id, tag.Value, page, year, month);
            else model = _api.Archives.GetById<Models.BlogArchive>(id, page, year, month);

            ArchiveViewModel archiveViewModel = new ArchiveViewModel
            {
                BlogArchive = model,
            };

            return View(archiveViewModel);
        }

        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        [Route("post")]
        public IActionResult Post(Guid id)
        {
            var model = _api.Posts.GetById<Models.BlogPost>(id);

            PostViewModel postViewModel = new PostViewModel
            {
                BlogPost = model,
                BlogArchive = _api.Archives.GetById<BlogArchive>(model.BlogId, null, null, null, null),
                Categories = _api.Categories.GetAll(model.BlogId).ToList(),
                Tags = _api.Tags.GetAll(model.BlogId).ToList(),
            };

            return View(postViewModel);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public IActionResult Page(Guid id) 
        {
            var model = _api.Pages.GetById<Models.StandardPage>(id);

            return View(model);
        }

    }
}
