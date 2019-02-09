using System.Collections.Generic;
using System.Threading.Tasks;
using LamdaForum.Core.Models;

namespace LamdaForum.Core.Interfaces
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int id);
        Task UpdateForumTitle(int id, string newTitle);
        Task UpdateForumDescription(int id, string newDescription);
    }
}
