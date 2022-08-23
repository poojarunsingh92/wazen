using MediatR;
using WazenAdmin.Application.Responses;
using System.Collections.Generic;
using System;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintList
{
    public class GetComplaintListQuery : IRequest<Response<IEnumerable<ComplaintListVm>>>
    {
    }
}
