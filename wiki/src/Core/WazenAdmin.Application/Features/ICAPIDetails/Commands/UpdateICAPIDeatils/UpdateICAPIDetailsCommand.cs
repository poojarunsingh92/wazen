using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.UpdateICAPIDeatils
{
    public class UpdateICAPIDetailsCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
        public Guid ICID { get; set; }
        public string EndPointURL { get; set; }
        public string RequestType { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string APIType { get; set; }
    }
}
