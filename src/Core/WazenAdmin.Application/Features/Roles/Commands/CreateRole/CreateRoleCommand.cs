using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<Response<RolesResponse>>
    {
        public string Name { get; set; }
        public string token { get; set; }

        //public string ConcurrencyStamp { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Boolean isActive { get; set; }

        public Boolean ViewPermission { get; set; }

        public Boolean WritePermission { get; set; }

        public Boolean ReadPermission { get; set; }
    }
}
