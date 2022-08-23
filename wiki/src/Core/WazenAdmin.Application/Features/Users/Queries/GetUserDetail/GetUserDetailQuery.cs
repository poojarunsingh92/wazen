using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<Response<UserDetailVm>>
    {
        public Guid ID { get; set; }
    }
}
