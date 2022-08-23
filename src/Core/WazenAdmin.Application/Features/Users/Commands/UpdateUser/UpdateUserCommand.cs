using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Response<Guid>>
    {
       public Guid ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Guid RoleType { get; set; }
    }
}
