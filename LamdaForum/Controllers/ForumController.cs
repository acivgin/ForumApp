using System.Linq;
using LamdaForum.Core.Interfaces;
using LamdaForum.Web.Forum.Models;
using LamdaForum.Web.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace LamdaForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description,
                    Created = forum.Created
                });

            var forumModel = new ForumIndexModel { ForumList = forums };

            return View(forumModel);
        }
    }
}