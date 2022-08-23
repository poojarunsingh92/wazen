using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Contracts.Infrastructure;
using WazenAdmin.Application.Models.Mail;

namespace WazenAdmin.Application.UnitTests.Mocks
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
