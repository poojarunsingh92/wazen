using System.Threading.Tasks;
using WazenAdmin.Application.Models.Mail;

namespace WazenAdmin.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
