using MediatR;
using WazenAdmin.Application.Responses;
using System.Collections.Generic;
using System;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintListByCustomerID
{
    public class GetComplaintByCustomerIDListQuery : IRequest<Response<IEnumerable<ComplaintByCustomerIDListVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
