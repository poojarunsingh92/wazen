using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Queries.GetUserByUserId
{
   public class GetUserByUserIdQuery : IRequest<GetUserListVm>
    {

        public Guid UserId { get; set; }

    }
}
