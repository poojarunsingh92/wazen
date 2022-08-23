using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WazenIdentity.Application.Contracts.Infrastructure;
using WazenIdentity.Application.Models.Mail;

namespace WazenIdentity.Application.UnitTests.Mocks
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
