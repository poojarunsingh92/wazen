using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandResponse
    {
        public CreateUserCommandResponse()
        {

        }

        public CreateUserDto User { get; set; }
    }
}