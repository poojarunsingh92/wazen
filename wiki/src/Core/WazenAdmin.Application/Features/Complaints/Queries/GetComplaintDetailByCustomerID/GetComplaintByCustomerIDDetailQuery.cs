using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetailByCustomerID
{
    public class GetComplaintByCustomerIDDetailQuery : IRequest<Response<GetComplaintByCustomerIDDetailVm>>
    {
        public Guid CustomerID { get; set; }
    }
}
