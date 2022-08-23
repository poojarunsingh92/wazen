using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerByID
{
    public class GetCustomerByIDQuery : IRequest<Response<CustomerByIDVm>>
    {
        public Guid ID { get; set; }
    }
}
