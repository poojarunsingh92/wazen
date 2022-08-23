using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteByNINAndDOB
{
    public class GetQuoteByNINAndDOBVm
    {
        public Guid ID { get; set; }
        public int? SalutationId { get; set; }      //FK
        public string EnglishFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
