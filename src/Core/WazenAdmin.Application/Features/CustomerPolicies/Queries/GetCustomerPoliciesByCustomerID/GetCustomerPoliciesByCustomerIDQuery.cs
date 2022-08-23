using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.CustomerPolicies.Queries.GetCustomerPoliciesByCustomerID
{
    public class GetCustomerPoliciesByCustomerIDQuery : IRequest<Response<IEnumerable<CustomerPoliciesByCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
