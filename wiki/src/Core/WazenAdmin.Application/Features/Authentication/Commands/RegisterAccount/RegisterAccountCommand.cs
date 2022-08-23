using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Models.Authentication;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Authentication.Commands.RegisterAccount
{
    public class RegisterAccountCommand : IRequest<ServiceBaseResponse2<AdminResponse>>
    {

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public string RoleName { get; set; }
    }
}
