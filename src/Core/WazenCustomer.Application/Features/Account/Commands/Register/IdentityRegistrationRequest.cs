using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Account.Commands.Register
{
    public class IdentityRegistrationRequest
    {      
        public string FirstName { get; set; }      
        public string LastName { get; set; }     
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
