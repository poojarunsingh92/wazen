using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response<CreateCustomerDto>>
    {
        public int SalutationId { get; set; }      //FK
        public string EnglishFirstName { get; set; }
        public string EnglishMiddleName { get; set; }
        public string EnglishLastName { get; set; }
        public string ArabicFirstName { get; set; }
        public string ArabicMiddleName { get; set; }
        public string ArabicLastName { get; set; }
        public string Address { get; set; }
        public int NationalIdTypeId { get; set; }        //FK
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }             //FK
        public int OccupationId { get; set; }        //FK
        public int EducationId { get; set; }         //FK
        public int MaritalStatusId { get; set; }      //FK
        public Boolean IsActive { get; set; }
        public Boolean NewsLetterSubscription { get; set; }
        public string grandFatherName { get; set; }
        public string subtribeName { get; set; }
        public string familyName { get; set; }
        public string EnglishSecondName { get; set; }
        public string EnglishThirdName { get; set; }
        public string dateOfBirthH { get; set; }
        public string licenseList11 { get; set; }
        public string idExpiryDate { get; set; }
        public string occupationCode { get; set; }
        public string YakeenLogId { get; set; }
        public string idIssuePlace { get; set; }
        public string VerifyCode { get; set; }
        public Guid userId { get; set; }
        public Boolean IsDelete { get; set; } = false;
    }
}
