using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.UpdateInsuranceCompanies
{
   public class UpdateInsuranceCompaniesCommandHandler : IRequestHandler<UpdateInsuranceCompaniesCommand, Response<Guid>>
    {
        private readonly IInsuranceCompaniesRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateInsuranceCompaniesCommandHandler(IMapper mapper, IInsuranceCompaniesRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateInsuranceCompaniesCommand request, CancellationToken cancellationToken)
        {

            var userToUpdate = await _userRepository.GetByIdAsync(request.ID);

            if (userToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateInsuranceCompaniesCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, userToUpdate, typeof(UpdateInsuranceCompaniesCommand), typeof(WazenAdmin.Domain.Entities.InsuranceCompany));

            await _userRepository.UpdateAsync(userToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
