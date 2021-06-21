using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Piranha.Services;
using Talagozis.Website.Models.Cms.PostTypes;

namespace Talagozis.Website.App_Plugins.Extensions
{
    internal static class PiranhaApiExtensions
    {
        internal static async Task<ICollection<TPost>> GetAllAsync<TPost>(this IPostService postService, IEnumerable<Guid> blogIds) where TPost : BlogPost
        {
            List<TPost> diveSiteBlogPosts = new List<TPost>();
            foreach (Guid blogId in blogIds)
                diveSiteBlogPosts.AddRange(await postService.GetAllAsync<TPost>(blogId));

            return diveSiteBlogPosts;
        }
    }
}
