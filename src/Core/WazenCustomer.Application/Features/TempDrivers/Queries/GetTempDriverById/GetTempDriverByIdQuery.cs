using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetTempDriverById
{
    public class GetTempDriverByIdQuery : IRequest<Response<TempDriverDetailVm>>
    {
        public Guid Id { get; set; }
    }
}
