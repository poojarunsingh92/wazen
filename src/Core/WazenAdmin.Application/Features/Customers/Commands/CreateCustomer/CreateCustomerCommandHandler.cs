using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Infrastructure;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreateCustomerDto>>
    {
        private readonly IQueueService _queueService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<CreateCustomerCommandHandler> logger, IQueueService queueService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
            _queueService = queueService;
        }
        public async Task<Response<CreateCustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByNIN(request.NIN);
            if (customer != null)
            {
                var resp = new Response<CreateCustomerDto>();
                resp.Succeeded = false;
                resp.Message = "The Customer with the given NIN already exist";
                return resp;
            }

            var customers = _mapper.Map<Customer>(request);
            customers = await _customerRepository.AddAsync(customers);
            await _queueService.SendMessageAsync<Customer>(customers, "Customer");
            var response = new Response<CreateCustomerDto>();
            response.Data = _mapper.Map<CreateCustomerDto>(customers);
            response.Succeeded = true;
            response.Message = "success";
            _logger.LogInformation("Handle Completed");
            return response;
        }
    }
}
