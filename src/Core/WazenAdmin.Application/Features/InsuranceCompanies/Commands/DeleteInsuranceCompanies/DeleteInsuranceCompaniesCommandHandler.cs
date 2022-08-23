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

namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.DeleteInsuranceCompanies
{
  public class DeleteInsuranceCompaniesCommandHandler : IRequestHandler<DeleteInsuranceCompaniesCommand>
    {
        private readonly IInsuranceCompaniesRepository _userRepsitory;
        
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteInsuranceCompaniesCommandHandler(IInsuranceCompaniesRepository userRepsitory)
        {
            _userRepsitory = userRepsitory;           
        }

        public async Task<Unit> Handle(DeleteInsuranceCompaniesCommand request, CancellationToken cancellationToken)
        {
           var userToDelete = await _userRepsitory.GetByIdAsync(request.ID);

            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(WazenAdmin.Domain.Entities.InsuranceCompany), request.ID);
            }

            await _userRepsitory.DeleteAsync(userToDelete);
            return Unit.Value;
        }
    }
}
