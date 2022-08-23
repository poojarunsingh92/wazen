using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;
namespace WazenCustomer.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDQuery : IRequest<Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
