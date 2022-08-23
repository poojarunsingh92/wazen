using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;
using WazenAdmin.Application.Exceptions;

namespace WazenAdmin.Application.Features.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, Response<UserDetailVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserDetailQueryHandler(IMapper mapper, IUserRepository userRepository, ILogger<GetUserDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
        public async Task<Response<UserDetailVm>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.ID);
            if (user == null)
            {
                var resposeObject = new Response<UserDetailVm>(request.ID + " is not available");
                return resposeObject;
            }
            var users = new List<UserDetailVm>();

            UserDetailVm userD = new UserDetailVm();
            userD.ID = user.ID;
            userD.Name = user.Name;
            userD.Username = user.Username;
            userD.Email = user.Email;
            userD.ContactNo = user.ContactNo;
            userD.Designation = user.Designation;
            userD.Password = user.Password;
            userD.IsActive = user.IsActive;
            userD.Date = user.Date;
            var userDetailDto = _mapper.Map<UserDetailVm>(userD);
            var response = new Response<UserDetailVm>(userDetailDto);

            return response;
        }
    }
}