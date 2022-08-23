using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Complaints.Commands.DeleteComplaint
{
    public class DeleteComplaintCommand : IRequest
    {
        public int ID { get; set; }
    }
}
