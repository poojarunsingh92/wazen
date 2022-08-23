using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Occupations.Queries.GetOccupationById
{
    public class GetOccupationByIdQuery : IRequest<Response<GetOccupationListVm>>
    {
        public int Id { get; set; }
    }
}
