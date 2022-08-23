using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Account.Queries.CustomerExist
{
    public  class CustomerExistQuery : IRequest<Response<bool>>
    {
       public string Mobile { get; set; }
    }
}
