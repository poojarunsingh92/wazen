using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ILogger _logger;
        public UserRepository(ApplicationDbContext dbContext, ILogger<User> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == Email);
            return user;
        }

        public async Task<User> GetUserByEmailVerifyCode(string Email, string VerfiyCode)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == Email && x.VerifyCode==VerfiyCode);
            return user;
        }

        public async Task<User> GetUserByUserId(Guid UserId)
        {
            var usersData = _dbContext.Users.FirstOrDefault(x => x.Userid == UserId);
            return usersData;
        }

        //public async Task<User> GetByRoleTypeAsync(Guid roletype)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.RoleType == roletype);
        //    return user;
        //}
    }
}
