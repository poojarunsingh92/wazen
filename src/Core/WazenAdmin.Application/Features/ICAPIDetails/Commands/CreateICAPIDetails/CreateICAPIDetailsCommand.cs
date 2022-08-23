using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.CreateICAPIDetails
{
    public class CreateICAPIDetailsCommand : IRequest<Response<CreateICAPIDetailsDto>>
    {
        public Guid ICID { get; set; }
        public string EndPointURL { get; set; }
        public string RequestType { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string APIType { get; set; }
    }
}
