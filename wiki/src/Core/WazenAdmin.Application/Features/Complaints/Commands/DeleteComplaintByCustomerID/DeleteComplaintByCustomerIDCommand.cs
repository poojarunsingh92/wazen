using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaintByCustomerID
{
    public class DeleteComplaintByCustomerIDCommand : IRequest
    {
        public Guid CustomerID { get; set; }
    }
}
