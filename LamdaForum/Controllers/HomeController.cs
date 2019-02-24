using System;
using System.Diagnostics;
using System.Linq;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using LamdaForum.Web.Forum.Models;
using LamdaForum.Web.Models;
using LamdaForum.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace LamdaForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View(BuildHomeIndexModel());
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);

            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.PostReplies.Count(),
                Forum = BuildForumForPost(post)
            });

            var model = new HomeIndexModel
            {
                SearchQuery = "",
                LatestPosts = posts
            };
            return model;
        }

        private ForumListingModel BuildForumForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Name,
                Created = forum.Created,
                ImageUrl = forum.ImageUrl
            };
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
