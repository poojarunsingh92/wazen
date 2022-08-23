using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
   public class AuthenticationAdminResponse
    {
        public Boolean Succeeded { get; set; }
        public string Message { get; set; }

        public string? Errors { get; set; }
        public bool IsAuthenticated { get; set; }


        /* public string Id { get; set; }
         public string UserName { get; set; }
         public string Email { get; set; }*/
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
       
        public UserAdmin userAdmin { get; set; }
    }

    public class UserAdmin
    { 
    public UserDetails userDetails { get; set; }

    public AdminData adminData { get; set; }
    }

    public class UserDetails
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool EmailConfirmed { get; set; }
        //public Roles Role { get; set; }
        public Role Roles { get; set; }
    }
    public class Roles
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class AdminData
    {
        public Guid id { get; set; }
        public string contactNo { get; set; }
        public string designation { get; set; }
        public Boolean isActive { get; set; }
    }
}
