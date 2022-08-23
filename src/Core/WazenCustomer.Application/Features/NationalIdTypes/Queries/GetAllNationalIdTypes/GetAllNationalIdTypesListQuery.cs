using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.NationalIdTypes.Queries.GetAllNationalIdTypes
{
   public class GetAllNationalIdTypesListQuery: IRequest<Response<IEnumerable<NationalIdTypesListVm>>>
    {
    }
}
