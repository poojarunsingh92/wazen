using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Identity;

namespace WazenAdmin.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<CreateUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public async Task<Response<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserCommandResponse = new Response<CreateUserDto>();

            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserCommandResponse.Succeeded = false;
                createUserCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createUserCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var user = new User()
                {
                    ID = System.Guid.NewGuid(),
                    //Userid = request.Userid,
                    Name = request.Name,
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    ContactNo = request.ContactNo,
                    Designation = request.Designation,
                    Date = request.Date,
                    IsActive = request.IsActive,
                    //RoleType = request.RoleType

                };
                user = await _userRepository.AddAsync(user);
                createUserCommandResponse.Data = _mapper.Map<CreateUserDto>(user);
                createUserCommandResponse.Succeeded = true;
                createUserCommandResponse.Message = "success";


            }
            return createUserCommandResponse;
        }
    }
}
