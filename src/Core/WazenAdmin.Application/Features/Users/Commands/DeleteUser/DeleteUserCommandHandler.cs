using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WazenAdmin.Application.Contracts.Identity;
using WazenAdmin.Application.Models.Authentication;

namespace WazenAdmin.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepsitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAuthenticationService _authenticationService;

        public DeleteUserCommandHandler( IUserRepository userRepsitory, IAuthenticationService authenticationService)
        {
            _userRepsitory = userRepsitory;
            _authenticationService = authenticationService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _userRepsitory.GetByIdAsync(request.ID);

            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(User), request.ID);
            }
            else
            {
                //Deleting from user table
                await _userRepsitory.DeleteAsync(userToDelete);

                //Deleting from identity table
                //DeleteRequest deleteRequest = new DeleteRequest();
                //deleteRequest.Id = userToDelete.UserId;
                //var deleteResponse=await _authenticationService.DeleteUserAsync(deleteRequest);

                return Unit.Value;
            }            
        }
    }
}
