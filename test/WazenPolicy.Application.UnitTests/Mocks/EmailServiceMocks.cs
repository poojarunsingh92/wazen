using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Contracts.Infrastructure;
using WazenPolicy.Application.Models.Mail;

namespace WazenPolicy.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var mockEmailService = new Mock<IEmailService>();
            mockEmailService.Setup(x => x.SendEmail(It.IsAny<Email>())).ReturnsAsync(true);
            return mockEmailService;
        }
    }
}
