using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Queries.GetComplaintDetail
{
    public class GetComplaintDetailQuery : IRequest<Response<ComplaintDetailVm>>
    {
        public int ID { get; set; }
    }
}
