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

namespace WazenAdmin.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<Guid>>
    {

        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IQueueService _queueService;

        public UpdateCustomerCommandHandler(IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger, ICustomerRepository customerRepository, IQueueService queueService)
        {
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
            _queueService = queueService;

        }
        public async Task<Response<Guid>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customerToUpdate = await _customerRepository.GetByIdAsync(request.ID);

            if (customerToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));
            await _customerRepository.UpdateAsync(customerToUpdate);
            await _queueService.SendMessageAsync<Customer>(customerToUpdate, "Customer");
            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
