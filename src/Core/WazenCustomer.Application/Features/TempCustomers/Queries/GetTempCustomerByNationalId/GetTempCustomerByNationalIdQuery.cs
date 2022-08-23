using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByNationalId
{
   public class GetTempCustomerByNationalIdQuery : IRequest<Response<TempCustomerByNationalIdVm>>
    {
        public string NIN { get; set; }
    }
}
