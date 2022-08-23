using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Queries.VerifyOTP
{
   public class VerifyOTPQueryHandler : IRequestHandler<VerifyOTPQuery, Response<VerifyOTPVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public VerifyOTPQueryHandler(IMapper mapper, IUserRepository userRepository, ILogger<VerifyOTPQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task<Response<VerifyOTPVm>> Handle(VerifyOTPQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailVerifyCode(request.Email, request.VerifyCode);

            if (user == null)
            {
                var resposeObject = new Response<VerifyOTPVm>(request.Email + " or " + request.VerifyCode + " is incorrect");
                return resposeObject;
            }
            var userDetailDto = _mapper.Map<VerifyOTPVm>(user);
            var response = new Response<VerifyOTPVm>(userDetailDto, "success");
            return response;
            
        }
    }
}
