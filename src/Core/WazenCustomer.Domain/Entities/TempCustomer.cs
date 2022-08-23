﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class TempCustomer : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public int? SalutationId { get; set; }      //FK
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
        public int? GenderId { get; set; }             //FK
        public int? OccupationId { get; set; }        //FK
        public int? EducationId { get; set; }         //FK
        public int? MaritalStatusId { get; set; }     //FK
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

        [ForeignKey("SalutationId")]
        public Salutation Salutation { get; set; }
        [ForeignKey("NationalIdTypeId")]
        public NationalIdType NationalIdType { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }
        [ForeignKey("EducationId")]
        public Education Education { get; set; }
        [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}