using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Queries.GetVehicleViolationById
{
   public class GetVehicleViolationByIdQuery : IRequest<Response<GetVehicleViolationListVm>>
    {
        public Guid Id { get; set; }
    }
}
