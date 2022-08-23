using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.Malath.Commands.MalathPolicy
{
    public class MalathPolicyResponse
    {
        public Guid RequestReferenceNo { get; set; }
        public int StatusCode { get; set; }
        public string PolicyNo { get; set; }
        public DateTime PolicyIssuanceDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public string PolicyFileUrl { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}