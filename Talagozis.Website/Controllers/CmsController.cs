using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Linq;
using System.Threading.Tasks;
using Piranha.Models;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
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
            this._api = api;
        }


        /// <summary>
        /// Gets the blog page with the given id.
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
            BlogArchive blogArchive = await this._api.Pages.GetByIdAsync<BlogArchive>(id);
            PostArchive<BlogPost> postArchive = await this._api.Archives.GetByIdAsync<BlogPost>(id, page, category, tag, year, month, pageSize: 20);

            ArchiveViewModel archiveViewModel = new ArchiveViewModel
            {
                blogArchive = blogArchive,
                PostArchive = postArchive
            };

            return this.View(archiveViewModel);
        }


        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The unique post id</param>
        [Route("post")]
        public async Task<IActionResult> Post(Guid id)
        {
            BlogPost blogPost = await this._api.Posts.GetByIdAsync<BlogPost>(id);

            BlogArchive blogArchive = await this._api.Pages.GetByIdAsync<BlogArchive>(blogPost.BlogId);
            PostArchive<BlogPost> postArchive = await this._api.Archives.GetByIdAsync<BlogPost>(blogPost.BlogId, null, null, null, null, null, pageSize: 20);

            PostViewModel postViewModel = new PostViewModel
            {
                BlogPost = blogPost,
                blogArchive = blogArchive,
                PostArchive = postArchive
            };

            return this.View(postViewModel);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id) 
        {
            var model = await this._api.Pages.GetByIdAsync<StandardPage>(id);

            return this.View(model);
        }

    }
}
