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
        [Route("archive")]
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
            BlogPost blogPost = await _api.Posts.GetByIdAsync<BlogPost>(id);

            BlogArchive blogArchive = await this._api.Pages.GetByIdAsync<BlogArchive>(blogPost.BlogId);
            blogArchive.Archive = await _api.Archives.GetByIdAsync(blogPost.BlogId, null, null, null, null, null);

            PostViewModel postViewModel = new PostViewModel
            {
                BlogPost = blogPost,
                BlogArchive = blogArchive,
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
