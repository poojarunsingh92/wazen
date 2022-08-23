using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.UpdateCustomerVehicle
{
    public class UpdateCustomerVehicleCommandHandler : IRequestHandler<UpdateCustomerVehicleCommand, Response<Guid>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerVehicleCommandHandler> _logger;

        public UpdateCustomerVehicleCommandHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, ILogger<UpdateCustomerVehicleCommandHandler> logger)
        {
            _mapper = mapper;
            _customerVehicleRepository = customerVehicleRepository;
            _logger = logger;

        }
        public async Task<Response<Guid>> Handle(UpdateCustomerVehicleCommand request, CancellationToken cancellationToken)
        {
            var customerVehicleToUpdate = await _customerVehicleRepository.GetByIdAsync(request.ID);

            if (customerVehicleToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, customerVehicleToUpdate, typeof(UpdateCustomerVehicleCommand), typeof(CustomerVehicle));
            await _customerVehicleRepository.UpdateAsync(customerVehicleToUpdate);

            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
