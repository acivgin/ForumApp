using LamdaForum.Web.Models.Posts;
using System.Collections.Generic;

namespace LamdaForum.Web.Models
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
