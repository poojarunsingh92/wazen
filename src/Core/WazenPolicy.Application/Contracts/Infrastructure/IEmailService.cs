using System.Threading.Tasks;
using WazenPolicy.Application.Models.Mail;

namespace WazenPolicy.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
