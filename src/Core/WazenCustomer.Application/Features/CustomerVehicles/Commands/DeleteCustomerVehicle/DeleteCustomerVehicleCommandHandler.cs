using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.DeleteCustomerVehicle
{
    public class DeleteCustomerVehicleCommandHandler : IRequestHandler<DeleteCustomerVehicleCommand>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerVehicleCommandHandler> _logger;

        public DeleteCustomerVehicleCommandHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, ILogger<CreateCustomerVehicleCommandHandler> logger)
        {
            _mapper = mapper;
            _customerVehicleRepository = customerVehicleRepository;
            _logger = logger;

        }
        public async Task<Unit> Handle(DeleteCustomerVehicleCommand request, CancellationToken cancellationToken)
        {
            var customerVehicleToDelete = await _customerVehicleRepository.GetByIdAsync(request.ID);
            if (customerVehicleToDelete == null)
            {
                throw new NotFoundException(nameof(CustomerVehicle), request.ID);
            }
            await _customerVehicleRepository.DeleteAsync(customerVehicleToDelete);
            return Unit.Value;
        }
    }
}
