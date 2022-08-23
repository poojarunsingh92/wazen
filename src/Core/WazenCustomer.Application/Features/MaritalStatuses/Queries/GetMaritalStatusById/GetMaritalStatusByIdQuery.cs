using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.MaritalStatuses.Queries.GetMaritalStatusById
{
   public class GetMaritalStatusByIdQuery : IRequest<Response<GetMaritalStatusListVm>>
    {
        public int Id { get; set; }
    }
}
