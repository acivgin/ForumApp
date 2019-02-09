using LamdaForum.Core;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LamdaForum.Service.Post
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _dbContext;
        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(Core.Models.Post post)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply postReply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Core.Models.Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Post> GetPostsByForum(int id)
        {
            return _dbContext.Forums.Where(forum => forum.Id == id).First().Posts;
        }
    }
}
