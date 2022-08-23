using System.Threading.Tasks;
using WazenIdentity.Application.Models.Mail;

namespace WazenIdentity.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
