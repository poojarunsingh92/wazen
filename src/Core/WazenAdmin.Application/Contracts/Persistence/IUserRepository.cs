using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByUserId(Guid UserId);

        Task<User> GetUserByEmail(string Email);

        Task<User> GetUserByEmailVerifyCode(string Email, string VerfiyCode);
        //Task<User> GetByRoleTypeAsync(Guid roletype);
    }
}
