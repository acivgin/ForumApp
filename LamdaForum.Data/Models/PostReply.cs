using System;

namespace LamdaForum.Core.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
        public virtual int PostId { get; set; }
    }
}