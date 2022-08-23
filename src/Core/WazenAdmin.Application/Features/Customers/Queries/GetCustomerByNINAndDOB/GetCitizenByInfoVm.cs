using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerByNINAndDOB
{
    public class GetCitizenByInfoVm
    {
        public int logId { get; set; }
        public string firstName { get; set; }
        public string fatherName { get; set; }
        public string grandFatherName { get; set; }
        public string subtribeName { get; set; }
        public string familyName { get; set; }
        public string englishFirstName { get; set; }
        public string englishSecondName { get; set; }
        public string englishThirdName { get; set; }
        public string englishLastName { get; set; }
        public int? genderId { get; set; }
        public string dateOfBirthH { get; set; }
        public string dateOfBirthG { get; set; }
        public string licenseList11 { get; set; }
        public string idExpiryDate { get; set; }
        public string idIssuePlace { get; set; }
        public string occupationCode { get; set; }
    }
}
