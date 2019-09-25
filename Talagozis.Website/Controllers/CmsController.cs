using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Linq;
using System.Threading.Tasks;
using Piranha.Models;
using Talagozis.Website.Models;
using Talagozis.Website.Models.ViewModels;

namespace Talagozis.Website.Controllers
{
    public class CmsController : BaseController
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
        //[Route("archive")]
        //public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null, Guid? category = null, Guid? tag = null) 
        //{
        //    Models.BlogArchive model;

        //    if (category.HasValue)
        //        model = _api.Archives.GetByCategoryId<Models.BlogArchive>(id, category.Value, page, year, month);
        //    else if (tag.HasValue)
        //        model = _api.Archives.GetByTagId<Models.BlogArchive>(id, tag.Value, page, year, month);
        //    else model = _api.Archives.GetById<Models.BlogArchive>(id, page, year, month);

        //    ArchiveViewModel archiveViewModel = new ArchiveViewModel
        //    {
        //        BlogArchive = model,
        //    };

        //    return View(archiveViewModel);
        //}
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null, Guid? category = null, Guid? tag = null)
        {
            var model = await _api.Pages.GetByIdAsync<BlogArchive>(id);
            model.Archive = await _api.Archives.GetByIdAsync(id, page, category, tag, year, month);

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
        public async Task<IActionResult> Post(Guid id)
        {
            var model = await _api.Posts.GetByIdAsync<BlogPost>(id);

            PostViewModel postViewModel = new PostViewModel
            {
                BlogPost = model,
                PostArchive = await _api.Archives.GetByIdAsync<PostBase>(model.BlogId, null, null, null, null, null, null),
                Categories = (await this._api.Posts.GetAllCategoriesAsync(model.BlogId)).ToList(),
                Tags = (await this._api.Posts.GetAllTagsAsync(model.BlogId)).ToList(),
            };

            return View(postViewModel);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id) 
        {
            var model = await _api.Pages.GetByIdAsync<Models.StandardPage>(id);

            return View(model);
        }

    }
}
