using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.ViolationTypes.Queries.GetViolationTypeById
{
   public class GetViolationTypeByIdQuery : IRequest<Response<GetViolationTypeListVm>>
    {
        public int Id { get; set; }

    }
}
