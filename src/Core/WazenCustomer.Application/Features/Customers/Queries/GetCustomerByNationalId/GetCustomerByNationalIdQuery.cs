using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerByNationalId
{
   public class GetCustomerByNationalIdQuery :IRequest<Response<CustomerByNationalIdVm>>
    {
        public string NIN { get; set; }
    }
}
