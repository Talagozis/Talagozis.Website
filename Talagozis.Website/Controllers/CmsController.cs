using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.Models;
using Talagozis.Website.Models.Cms.PageTypes;
using Talagozis.Website.Models.Cms.PostTypes;
using Talagozis.Website.Models.ViewModels;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Talagozis.Website.Models.Cms.Regions;

namespace Talagozis.Website.Controllers
{
    public class CmsController : BaseController
    {
        private readonly IApi _api;
        private readonly ILogger<CmsController> _logger;
        private CultureInfo _requestCulture;

        public CmsController(IApi api, ILogger<CmsController> logger)
        {
            this._api = api ?? throw new ArgumentNullException(nameof(api));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            this._requestCulture = context.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture?.Culture ?? throw new InvalidOperationException($"The {nameof(CultureInfo)} for this request is not defined.");

            await base.OnActionExecutionAsync(context, next);
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
        /// <param name="draft">The optional draft</param>
        [Route("archive")]
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null, Guid? category = null, Guid? tag = null, bool? draft = null)
        {
            BlogArchive blogArchive = await this._api.Pages.GetByIdAsync<BlogArchive>(id);

            if (!blogArchive.IsPublished && draft != true)
                return this.NotFound();

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
        /// <param name="draft">The optional draft</param>
        [Route("post")]
        public async Task<IActionResult> Post(Guid id, bool? draft = null)
        {
            BlogPost blogPost = await this._api.Posts.GetByIdAsync<BlogPost>(id);

            if (!blogPost.IsPublished && draft != true)
                return this.NotFound();

            BlogArchive blogArchive = await this._api.Pages.GetByIdAsync<BlogArchive>(blogPost.BlogId);
            PostArchive<BlogPost> postArchive = await this._api.Archives.GetByIdAsync<BlogPost>(blogPost.BlogId, null, null, null, null, null, pageSize: 20);

            CulturePage parentPage = blogArchive.ParentId.HasValue ? await this._api.Pages.GetByIdAsync<CulturePage>(blogArchive.ParentId.Value) : null;

            IDictionary<CultureInfo, BlogPost> cultureRelatedBlogPosts = new Dictionary<CultureInfo, BlogPost>
            {
                { this._requestCulture, blogPost }
            };

            foreach (RelatedCultureRegion relatedCulture in blogPost.RelatedCulturePost)
                cultureRelatedBlogPosts.Add(relatedCulture.Culture.Value.cultureInfo, await relatedCulture.RelatedPost.GetPostAsync<BlogPost>(this._api));

            PostViewModel postViewModel = new PostViewModel
            {
                BlogPost = blogPost,
                blogArchive = blogArchive,
                PostArchive = postArchive,
                cultureInfo = parentPage?.Culture?.Value?.cultureInfo ?? CultureInfo.InvariantCulture,
                CultureRelatedBlogPosts = cultureRelatedBlogPosts.Where(a => a.Value.IsPublished).ToDictionary(a => a.Key, a => a.Value)
            };

            return this.View(postViewModel);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        /// <param name="draft">The optional draft</param>
        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool? draft = null) 
        {
            StandardPage standardPage = await this._api.Pages.GetByIdAsync<StandardPage>(id);

            if (!standardPage.IsPublished && draft != true)
                return this.NotFound();

            return this.View(standardPage);
        }

    }
}
