using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetPolicyDetail
{
    public class GetCustomerPolicyDetailQuery : IRequest<Response<CustomerPolicyDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
