using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Educations.Queries.GetEducationById
{
   public class GetEducationByIdQuery : IRequest<Response<GetEducationListVm>>
    {
        public int Id { get; set; }
    }
}
