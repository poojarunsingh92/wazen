using WazenAdmin.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace WazenAdmin.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<Response<IEnumerable<UserListVm>>>
    {
    }
}
