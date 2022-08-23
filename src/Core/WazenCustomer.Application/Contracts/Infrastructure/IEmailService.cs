using System.Threading.Tasks;
using WazenCustomer.Application.Models.Mail;

namespace WazenCustomer.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
