using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Commands.UpdateComplaint
{
    public class UpdateComplaintCommand : IRequest<Response<int>>
    {
        public int ID { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailID { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintPriority { get; set; }
        public string Subject { get; set; }
        public string ComplaintMessage { get; set; }
    }
}
