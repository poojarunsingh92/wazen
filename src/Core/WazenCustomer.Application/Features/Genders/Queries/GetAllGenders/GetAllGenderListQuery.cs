using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Genders.Queries.GetAllGenders
{
   public class GetAllGenderListQuery : IRequest<Response<IEnumerable<GenderListVm>>>
    {
    }
}
