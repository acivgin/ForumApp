using LamdaForum.Core;
using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Posts.Add(post);
            return _dbContext.SaveChangesAsync();
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
            return _dbContext.Posts
                .Include(post => post.User)
                .Include(post => post.PostReplies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum);
        }

        public Core.Models.Post GetById(int id)
        {
            return _dbContext.Posts.Where(p => p.Id == id)
                .Include(post => post.User)
                .Include(post => post.PostReplies)
                .Include(post => post.Forum).FirstOrDefault();
        }

        public IEnumerable<Core.Models.Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Post> GetPostsByForum(int id)
        {
            return _dbContext.Forums.Where(forum => forum.Id == id).First().Posts;
        }

        public IEnumerable<Core.Models.Post> GetLatestPosts(int number)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(number);
        }
    }
}
