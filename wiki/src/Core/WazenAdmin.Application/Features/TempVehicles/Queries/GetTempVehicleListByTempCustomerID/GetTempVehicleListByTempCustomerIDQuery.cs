using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TempVehicles.Queries.GetTempVehicleListByTempCustomerID
{
    public class GetTempVehicleListByTempCustomerIDQuery : IRequest<Response<IEnumerable<TempVehicleListByTempCustomerIDVm>>>
    {
        public Guid CustomerID { get; set; }
    }
}
