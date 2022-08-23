using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList
{
    public class GetAllListCommand : IRequest<Response<List<GetAllListVM>>>
    {
        public Guid CustomerID { get; set; }
    }
}
