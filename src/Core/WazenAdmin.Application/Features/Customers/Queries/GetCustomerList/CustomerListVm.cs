using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerList
{
    public class CustomerListVm
    {
        public Guid ID { get; set; }
        public int SalutationId { get; set; }
        public string EnglishFirstName { get; set; }
        public string EnglishMiddleName { get; set; }
        public string EnglishLastName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public int NationalIdTypeId { get; set; }
        public string NIN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }             //FK
        public int OccupationId { get; set; }        //FK
        public int EducationId { get; set; }         //FK
        public int MaritalStatusId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsMain { get; set; } = true;
    }
}
