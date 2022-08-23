using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Account.Commands.Register
{
    public class RegistrationResponse
    {
        public Guid ID { get; set; }
        public int SalutationId { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishLastName { get; set; }

        public int NationalIdTypeId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string NIN { get; set; }
        public Boolean IsActive { get; set; }  
        public Guid userid { get; set; }
    }
}
