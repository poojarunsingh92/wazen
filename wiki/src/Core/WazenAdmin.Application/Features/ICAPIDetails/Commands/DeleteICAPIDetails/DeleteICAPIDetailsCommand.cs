using WazenAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetails
{
    public class DeleteICAPIDetailsCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
