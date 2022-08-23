using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.StaticContents.Queries.GetStaticContentDetail
{
    public class StaticContentDetailVm
    {
        //public Guid EventId { get; set; }
        public Guid ID { get; set; }
        public string AboutUs { get; set; }
        public string TermsAndCondition { get; set; }
        public string PartnerName { get; set; }
        public string PartnerLogo { get; set; }
        public string RedirectedURL { get; set; }
        public Boolean Status { get; set; }
        public string NameOfTheCompany { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaLink { get; set; }
        public string WebsiteLink { get; set; }
        public string GoogleLocation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
