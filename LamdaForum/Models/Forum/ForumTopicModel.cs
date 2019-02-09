using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamdaForum.Web.Forum.Models;
using LamdaForum.Web.Models.Posts;

namespace LamdaForum.Web.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
