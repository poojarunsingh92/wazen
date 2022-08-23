using WazenAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintCommand : IRequest<Response<CreateComplaintDto>>
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailID { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintPriority { get; set; }
        public string Subject { get; set; }
        public string ComplaintMessage { get; set; }
    }
}
