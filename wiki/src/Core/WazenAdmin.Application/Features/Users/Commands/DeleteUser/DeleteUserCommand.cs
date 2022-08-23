using MediatR;
using System;

namespace WazenAdmin.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
