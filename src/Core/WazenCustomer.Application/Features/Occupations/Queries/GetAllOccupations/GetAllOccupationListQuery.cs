using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Occupations.Queries.GetAllOccupations
{
   public class GetAllOccupationListQuery: IRequest<Response<IEnumerable<OccupationListVm>>>
    {
    }
}
