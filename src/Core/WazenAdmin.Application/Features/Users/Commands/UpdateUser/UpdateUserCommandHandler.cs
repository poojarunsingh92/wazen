using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Identity;
using WazenAdmin.Application.Models.Authentication;

namespace WazenAdmin.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<Guid>>
    {
        private readonly IUserRepository _userRepsitory;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
           
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _userRepsitory = userRepository;
            _authenticationService = authenticationService;
        }

        public async Task<Response<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var userToUpdate = await _userRepsitory.GetByIdAsync(request.ID);

            if (userToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }
            else
            {
                var validator = new UpdateUserCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);

                //string[] name = request.Name.Split(" ");
                //UpdateRequest updateRequest = new UpdateRequest();
                User updateRequest = new User();
                updateRequest.ID = userToUpdate.ID;
                updateRequest.Username = userToUpdate.Username;
                updateRequest.Name = userToUpdate.Name;
                updateRequest.Email = request.Email;
                updateRequest.ContactNo = userToUpdate.ContactNo;
                updateRequest.Designation = userToUpdate.Designation;
                updateRequest.Password = request.Password;
                updateRequest.IsActive = request.IsActive;
                updateRequest.Date = userToUpdate.Date;
                //updateRequest.RoleType = request.RoleType;
        
                

                //var userIdResponse = await _authenticationService.UpdateUserAsync(updateRequest);

                _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

                await _userRepsitory.UpdateAsync(userToUpdate);

                return new Response<Guid>(request.ID, "Updated successfully ");
            }        
        }
    }
}