using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using LamdaForum.Web.Models.Posts;
using LamdaForum.Web.Models.Reply;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;

namespace LamdaForum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        public PostController(IPost postService)
        {
            _postService = postService;
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

        [HttpPost]
        public IActionResult Create(PostIndexModel postIndexModel)
        {
            return null;
        }
    }
}