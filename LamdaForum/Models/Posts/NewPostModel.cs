namespace LamdaForum.Web.Models.Posts
{
    public class NewPostModel
    {
        public int ForumID { get; set; }
        public string ForumName { get; set; }
        public string ForumImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}