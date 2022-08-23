using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDQuery : IRequest<Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
