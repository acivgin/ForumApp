using System;
using System.Linq;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using LamdaForum.Web.Forum.Models;
using LamdaForum.Web.Models.Forum;
using LamdaForum.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc;

namespace LamdaForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Title = forum.Name,
                    Description = forum.Description,
                    Created = forum.Created
                });

            var forumModel = new ForumIndexModel { ForumList = forums };

            return View(forumModel);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                Title =  post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.PostReplies.Count(),
                Forum = BuildForulmListing(post)
            });

            return View(forum);
        }

        private ForumListingModel BuildForulmListing(Post post)
        {
            throw new NotImplementedException();
        }
    }
}