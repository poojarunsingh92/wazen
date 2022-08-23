using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationById
{
   public class GetTempVehicleViolationByIdQuery : IRequest<Response<GetTempVehicleViolationListVm>>
    {
        public Guid Id { get; set; }
    }
}
