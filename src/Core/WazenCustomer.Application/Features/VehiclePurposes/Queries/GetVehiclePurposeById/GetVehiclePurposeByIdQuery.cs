using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehiclePurposes.Queries.GetVehiclePurposeById
{
   public class GetVehiclePurposeByIdQuery : IRequest<Response<GetVehiclePurposeListVm>>
    {
        public int Id { get; set; }
    }
}
