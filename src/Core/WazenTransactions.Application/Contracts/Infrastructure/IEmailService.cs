using System.Threading.Tasks;
using WazenTransactions.Application.Models.Mail;

namespace WazenTransactions.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
