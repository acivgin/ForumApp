using System;

namespace LamdaForum.Web.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthoName { get; set; }
        public int AuthoRating { get; set; }

        public string AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }

        public int PostId { get; set; }
    }
}
