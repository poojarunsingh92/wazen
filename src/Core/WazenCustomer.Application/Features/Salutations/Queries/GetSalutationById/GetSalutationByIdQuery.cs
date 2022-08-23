using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Salutations.Queries.GetSalutationById
{
   public class GetSalutationByIdQuery : IRequest<Response<GetSalutationListVm>>
    {
        public int Id { get; set; }
    }
}
