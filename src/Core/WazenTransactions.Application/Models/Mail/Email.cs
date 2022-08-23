
using System.Net.Mail;

namespace WazenTransactions.Application.Models.Mail
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Attachment Attachments { get; set; }
    }
}
