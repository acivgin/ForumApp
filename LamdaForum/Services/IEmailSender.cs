using System.Threading.Tasks;

namespace LamdaForum.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
