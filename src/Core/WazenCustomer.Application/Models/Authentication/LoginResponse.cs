using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Models.Authentication
{
    public class LoginResponse
    {
        public Boolean succeeded { get; set; }
        public string message { get; set; }

        public string? errors { get; set; }
        public bool isAuthenticated { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime? refreshTokenExpiration { get; set; }
        public User data { get; set; }
    }
    public class User
    {
        public UserDetials userData { get; set; }
        public CustomerData customerData { get; set; }
    }
    public class UserDetials
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool emailConfirmed { get; set; }
        public Role role { get; set; }

    }
    public class Role
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
    }
    public class CustomerData
    {
        public Guid id { get; set; }

        public DateTime dateOfBirth { get; set; }

    }
}
