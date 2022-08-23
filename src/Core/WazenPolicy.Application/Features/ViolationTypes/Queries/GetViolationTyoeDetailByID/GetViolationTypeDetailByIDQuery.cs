using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID
{
    public class GetViolationTypeDetailByIDQuery : IRequest<Response<ViolationTypeDetailVm>>
    {
        public int ID { get; set; }
    }
}
