using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.FAQ.Commands.UpdateFAQ
{
    public class UpdateFAQCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Module { get; set; }
        public Boolean DisplayOnHome { get; set; }
        public Boolean Status { get; set; }
    }

}
