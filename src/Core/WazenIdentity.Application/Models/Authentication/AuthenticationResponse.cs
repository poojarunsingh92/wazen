using System;

namespace WazenIdentity.Application.Models.Authentication
{
    //public class AuthenticationResponse
    //{
    //    public string Message { get; set; }
    //    public bool IsAuthenticated { get; set; }
    //    public string Id { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public string Token { get; set; }
    //    public string Role { get; set; }
    //    public string RefreshToken { get; set; }
    //    public DateTime? RefreshTokenExpiration { get; set; }
    //}
    public class AuthenticationResponse
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
        public User Data { get; set; }
    }
    public class User
    {
        public UserDetials UserData { get; set; }
        public CustomerData CustomerData { get; set; }
    }
    public class UserDetials
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool EmailConfirmed { get; set; }
        public Role Role { get; set; }

    }
    public class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class CustomerData
    {
        public Guid id { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
