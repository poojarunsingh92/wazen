using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteByNINAndDOB
{
    public class GetQuoteByNINAndDOBQuery : IRequest<Response<GetQuoteByNINAndDOBVm>>
    {
        public string NIN { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
