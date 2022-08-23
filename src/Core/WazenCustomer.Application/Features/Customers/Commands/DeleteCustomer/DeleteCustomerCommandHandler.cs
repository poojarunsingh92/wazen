using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;
        private readonly IQueueService _queueService;

        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<DeleteCustomerCommandHandler> logger, IQueueService queueService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _queueService = queueService;
            _logger = logger;

        }
        public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var customerToDelete = await _customerRepository.GetByIdAsync(request.ID);
            if (customerToDelete == null)
            {
                var resposeObject = new Response<bool>(request.ID + " is not available");
                return resposeObject;
            }
            customerToDelete.IsDelete = true;
            await _customerRepository.UpdateAsync(customerToDelete);
            await _queueService.SendMessageAsync<Customer>(customerToDelete, "Customer");
            response.Succeeded = true;
            response.Message = "Deleted Successfully";
            response.Errors = null;
            response.Data = true;
            return response;
        }
    }
}
