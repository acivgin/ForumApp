using System;
using System.Collections.Generic;
using LamdaForum.Web.Models.Reply;

namespace LamdaForum.Web.Models.Posts
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthoName { get; set; }
        public int AuthoRating { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }

        public IEnumerable<PostReplyModel> PostReplies { get; set; }
    }
}
