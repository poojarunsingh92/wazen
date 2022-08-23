using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer
{
   public class CustomerRequest
    {
        public Guid CustomerId { get; set; }
        public int? SalutationId { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
