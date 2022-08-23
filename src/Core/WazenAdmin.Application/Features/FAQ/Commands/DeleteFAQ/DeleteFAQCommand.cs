using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Commands.DeleteFAQ
{
    public class DeleteFAQCommand : IRequest<Response<bool>>
    {
        public Guid ID { get; set; }
    }

}
