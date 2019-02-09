using LamdaForum.Web.Forum.Models;
using System.Collections.Generic;

namespace LamdaForum.Web.Models.Forum
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumListingModel> ForumList { get; set; }
    }
}
