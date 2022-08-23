using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathPolicy
{
    public class MalathPolicyCommand : IRequest<Response<MalathPolicyResponse>>
    {
        public Guid RequestReferenceNo { get; set; }
        public string QuotationNo { get; set; }
        public string ProductId { get; set; }
        public List<Cover> Covers { get; set; }
        public int InsuredId { get; set; }
        public string InsuredMobileNumber { get; set; }
        public string InsuredEmail { get; set; }
        public int InsuredBuildingNo { get; set; }
        public int InsuredZipCode { get; set; }
        public int InsuredAdditionalNumber { get; set; }
        public int InsuredUnitNo { get; set; }
        public string InsuredCity { get; set; }
        public string InsuredDistrict { get; set; }
        public string InsuredStreet { get; set; }
        public int PaymentMethodCode { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentBillNumber { get; set; }
        public string InsuredBankCode { get; set; }
        public string PaymentUsername { get; set; }
        public string InsuredIBAN { get; set; }
    }
    public class Cover
    {
        public int CoverCode { get; set; }
        public string CoverId { get; set; }
        public string CoverNameAr { get; set; }
        public string CoverNameEn { get; set; }
        public decimal CoverPrice { get; set; }
    }
}