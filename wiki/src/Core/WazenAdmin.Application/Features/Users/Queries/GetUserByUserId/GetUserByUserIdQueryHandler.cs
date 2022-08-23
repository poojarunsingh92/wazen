using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;

namespace WazenAdmin.Application.Features.Users.Queries.GetUserByUserId
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, GetUserListVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByUserIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<GetUserListVm> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _userRepository.GetUserByUserId(request.UserId);
            if (customer == null)
            {
                var resposeObject = new GetUserListVm();
                return resposeObject;
            }

            var response = _mapper.Map<GetUserListVm>(customer);

            return response;
        }
    }
}
