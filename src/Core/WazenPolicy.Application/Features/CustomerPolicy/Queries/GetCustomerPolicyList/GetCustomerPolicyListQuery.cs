using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyList
{
    public class GetCustomerPolicyListQuery : IRequest<Response<IEnumerable<CustomerPolicyListVm>>>
    {
    }
}
