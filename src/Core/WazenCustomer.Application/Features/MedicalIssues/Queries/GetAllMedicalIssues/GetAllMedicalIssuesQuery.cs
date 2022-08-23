using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.MedicalIssues.Queries.GetAllMedicalIssues
{
    public class GetAllMedicalIssuesQuery : IRequest<Response<IEnumerable<MedicalIssuesListVm>>>
    {
    }
}
