using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;
namespace WazenCustomer.Application.Features.Account.Commands.Register
{
    public class CreateRegistrationRequestCommand : IRequest<Response<RegistrationResponse>>
    {
        public int SalutationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalIdTypeId { get; set; }
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; } 
        public string RoleName { get; set; }
    }
}
