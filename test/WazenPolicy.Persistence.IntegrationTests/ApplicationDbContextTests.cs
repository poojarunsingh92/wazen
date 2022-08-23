using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using WazenPolicy.Application.Contracts;
using Xunit;

namespace WazenPolicy.Persistence.IntegrationTests
{
    public class ApplicationDbContextTests
    {
        private readonly ApplicationDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public ApplicationDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globoTicketDbContext = new ApplicationDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }


        // [Fact]
        public async void Save_SetCreatedByProperty()
        {            
        }
    }
}
