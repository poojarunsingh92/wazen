using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Educations.Queries.GetAllEducations
{
    public class GetAllEducationListQuery : IRequest<Response<IEnumerable<EducationListVm>>>
    {
    }
}
