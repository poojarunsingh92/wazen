using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintDto
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
