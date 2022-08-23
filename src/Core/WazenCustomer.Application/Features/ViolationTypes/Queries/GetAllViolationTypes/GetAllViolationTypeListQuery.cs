using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.ViolationTypes.Queries.GetAllViolationTypes
{
    public class GetAllViolationTypeListQuery : IRequest<Response<IEnumerable<ViolationTypeListVm>>>
    {
    }
}
