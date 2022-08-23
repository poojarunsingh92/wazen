using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaPolicy
{
    public class WalaaPolicyCommand : IRequest<Response<WalaaPolicyResponse>>
	{
		public string ProviderCompanyCode { get; set; } = "25";
		public string ProviderCompanyName { get; set; } = "WZANBroker";
		public string ReferenceId { get; set; } = "dab92f1aae87493";
		public string QuotationNo { get; set; } = "P03-QN-21-300-0000000417";
		public string ProductId { get; set; } = "2250";
		public /*int*/ string InsuredId { get; set; } = "2198197184";
		public string InsuredMobileNumber { get; set; } = "0500995104";
		public string InsuredEmail { get; set; } = "suhesh@walaa.com";
		public int InsuredBuildingNo { get; set; } = 3939;
		public int InsuredZipCode { get; set; } = 23337;
		public int InsuredAdditionalNumber { get; set; } = 7938;
		public int InsuredUnitNo { get; set; } = 17;
		public string InsuredCity { get; set; } = "جدة";
		public string InsuredDistrict { get; set; } = "حي العزيزية";
		public string InsuredStreet { get; set; } = "غير معروف";
		public int PaymentMethodCode { get; set; } = 1;
		public string PaymentMethod { get; set; } = null;
		public float PaymentAmount { get; set; } = 2541.07f;
		public string PaymentBillNumber { get; set; } = "504814300";
		public string PaymentUsername { get; set; } = "UNKNOWN";
		public string InsuredIBAN { get; set; } = "SA1210567890123456789012";
		public string InsuredBankCode { get; set; } = "10";
		public List<Benefit> Benefits { get; set; } = new List<Benefit>() { new Benefit(), new Benefit() };
	}
	public class Benefit
	{
		public string BenefitId { get; set; } = "145";
	}
}
