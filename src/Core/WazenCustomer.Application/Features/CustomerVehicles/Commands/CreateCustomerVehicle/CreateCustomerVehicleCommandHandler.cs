using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle
{
    public class CreateCustomerVehicleCommandHandler : IRequestHandler<CreateCustomerVehicleCommand, Response<CustomerVehicleDto>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerVehicleCommandHandler> _logger;
       


        public CreateCustomerVehicleCommandHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, ILogger<CreateCustomerVehicleCommandHandler> logger)
        {
            _mapper = mapper;
            _customerVehicleRepository = customerVehicleRepository;
            _logger = logger;
            
        }
        public async Task<Response<CustomerVehicleDto>> Handle(CreateCustomerVehicleCommand request, CancellationToken cancellationToken)
        {

            var customerVehicle = _mapper.Map<CustomerVehicle>(request);

            var customerVehicleDto = await _customerVehicleRepository.AddAsync(customerVehicle);

            var response = new Response<CustomerVehicleDto>("Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;

        }
    }
}
