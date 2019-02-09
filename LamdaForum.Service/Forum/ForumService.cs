using LamdaForum.Core.Interfaces;
using LamdaForum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamdaForum.Core;
using Microsoft.EntityFrameworkCore;

namespace LamdaForum.Service.Forum
{
    class ForumService : IForum
    {
        private readonly ApplicationDbContext _dbContext;
        public ForumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Core.Models.Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.Forum> GetAll()
        {
            return _dbContext.Forums.Include(f => f.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Core.Models.Forum GetById(int id)
        {
            var forum = _dbContext.Forums.Where(f => f.Id == id).First();
            if(forum == null) 
                return new Core.Models.Forum();

            return forum;
        }

        public Task UpdateForumDescription(int id, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int id, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
