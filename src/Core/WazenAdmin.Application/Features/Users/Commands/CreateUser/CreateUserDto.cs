using System;

namespace WazenAdmin.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserDto
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }

        public Guid RoleType { get; set; }
    }
}
