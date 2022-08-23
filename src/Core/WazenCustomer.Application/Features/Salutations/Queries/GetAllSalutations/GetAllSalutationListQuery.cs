using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Salutations.Queries.GetAllSalutations
{
  public class GetAllSalutationListQuery: IRequest<Response<IEnumerable<SalutationListVm>>>
    {
    }
}
