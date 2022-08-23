using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByCustomerId
{
    public class GetTempCustomerByCustomerIdQuery : IRequest<Response<TempCustomerByCustomerIdVm>>
    {
        public Guid Id { get; set; }
    }
}
