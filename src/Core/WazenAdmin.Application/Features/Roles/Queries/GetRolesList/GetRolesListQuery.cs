using MediatR;
using WazenAdmin.Application.Responses;
using System.Collections.Generic;
using System;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRolesListQuery : IRequest<Response<IEnumerable<RoleListVM>>>
    {
       // public Guid Id { get; set; }
       public string token { get; set; }
    }
}
