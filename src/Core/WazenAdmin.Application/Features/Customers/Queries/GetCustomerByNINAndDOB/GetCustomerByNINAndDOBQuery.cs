using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerByNINAndDOB
{
    public class GetCustomerByNINAndDOBQuery : IRequest<Response<GetCustomerByNINAndDOBVm>>
    {
        public string NIN { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
