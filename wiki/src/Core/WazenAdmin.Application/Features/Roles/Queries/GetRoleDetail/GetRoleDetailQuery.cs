using MediatR;
using WazenAdmin.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRoleDetail
{
  public class GetRoleDetailQuery : IRequest<Response<RoleDetailVm>>
    {
        public string ID { get; set; }
        public string Token { get; set; }
    }

}
