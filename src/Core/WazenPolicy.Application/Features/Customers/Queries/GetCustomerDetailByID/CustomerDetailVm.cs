using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID
{
    public class CustomerDetailVm
    {
        public Guid ID { get; set; }
        public int? SalutationId { get; set; }        //FK
        public string EnglishFirstName { get; set; }
        public string EnglishMiddleName { get; set; }
        public string EnglishLastName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public string Address { get; set; }
        public int? NationalIdTypeId { get; set; }        //FK
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
