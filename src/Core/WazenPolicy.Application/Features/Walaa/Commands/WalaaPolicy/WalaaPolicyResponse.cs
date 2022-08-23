using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Walaa.Commands.WalaaPolicy
{
    public class WalaaPolicyResponse
	{
		public string ReferenceId { get; set; }
		public int StatusCode { get; set; }
		public string QuotationNo { get; set; }
		public string PolicyNo { get; set; }
		public DateTime PolicyEffectiveDate { get; set; }
		public DateTime PolicyIssuanceDate { get; set; }
		public DateTime PolicyExpiryDate { get; set; }
		public string PolicyFileUrl { get; set; }
		public List<Error> Errors { get; set; }
	}

	public class Error
	{
		public string Message { get; set; }
		public string Code { get; set; }
		public string Field { get; set; }
	}
}
