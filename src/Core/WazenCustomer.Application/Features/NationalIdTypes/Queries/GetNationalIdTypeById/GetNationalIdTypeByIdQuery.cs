using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.NationalIdTypes.Queries.GetNationalIdTypeById
{
   public class GetNationalIdTypeByIdQuery : IRequest<Response<GetNationalIdListVm>>
    {
        public int Id { get; set; }
    }
}
