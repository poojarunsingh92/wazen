using MediatR;
using System;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Roles.Commands.DeleteRole
{
   public  class DeleteRoleCommand : IRequest<Response<DeleteResponse>>
    {
        public string ID { get; set; }
        public string token { get; set; }
    }
        
}
