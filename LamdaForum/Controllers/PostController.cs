using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using LamdaForum.Web.Models.Posts;
using LamdaForum.Web.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;

namespace LamdaForum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private static UserManager<ApplicationUser> _userManager;

        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostRepliesModel(post.PostReplies);

            var postModel = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthoName = post.User.UserName,
                AuthoRating = post.User.Rating,
                AuthorImageUrl = post.User.ProfileImageUrl,
                Created = post.Created,
                PostContent = post.Content,
                PostReplies = replies
            };

            return View(postModel);
        }

        private IEnumerable<PostReplyModel> BuildPostRepliesModel(IEnumerable<PostReply> postReplies)
        {
            return postReplies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                Title = reply.Title,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthoRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            //id is Forum.Id
            var forum = _forumService.GetById(id);

            var newPost = new NewPostModel
            {
                ForumID = forum.Id,
                ForumName = forum.Name,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(newPost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPostModel postIndexModel)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var post = BuildPost(postIndexModel, user);

            await _postService.Add(post);

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPost(NewPostModel postIndexModel, ApplicationUser user)
        {
            return new Post
            {
                ForumId = postIndexModel.ForumID,
                Title = postIndexModel.Title,
                Content = postIndexModel.Content,
                Created = DateTime.Now,
                User = user
            };
        }
    }
}