using WazenAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<Response<UpdateRolesResponse>>
    {

        public Guid Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        //public string ConcurrencyStamp { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Boolean isActive { get; set; }

        public Boolean ViewPermission { get; set; }

        public Boolean WritePermission { get; set; }

        public Boolean ReadPermission { get; set; }
    }
}
