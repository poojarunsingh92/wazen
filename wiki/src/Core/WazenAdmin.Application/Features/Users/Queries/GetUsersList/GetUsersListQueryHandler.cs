using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, Response<IEnumerable<UserListVm>>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetUsersListQueryHandler(IMapper mapper, IUserRepository userRepository, ILogger<GetUsersListQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<UserListVm>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allUsers = await _userRepository.ListAllAsync();

            var users = new List<UserListVm>();

            foreach (var item in allUsers)
            {
                UserListVm userD = new UserListVm();
                userD.ID = item.ID;
                userD.Name = item.Name;
                userD.Username = item.Username;
                userD.Email = item.Email;
                userD.ContactNo = item.ContactNo;
                userD.Designation = item.Designation;
                userD.Date = item.Date;
                userD.IsActive = item.IsActive;
               // userD.RoleType = item.RoleType;
                users.Add(userD);
            }

            //var user = _mapper.Map<IEnumerable<UserListVm>>(userD);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<UserListVm>>(users, "success");
        }
    }
}
