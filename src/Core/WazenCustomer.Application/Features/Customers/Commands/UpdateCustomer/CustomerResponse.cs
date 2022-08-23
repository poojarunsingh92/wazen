using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer
{
   public class CustomerResponse
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }

        public UpdateCustomerResponse data { get; set; }
    }

    public class UpdateCustomerResponse
    {
        public Guid customerId { get; set; }
        public int? salutationId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nIN { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string userid { get; set; }
    }
}
