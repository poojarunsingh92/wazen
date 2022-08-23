using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempCustomers.Commands.CreateTempCustomer
{
    public class CreateTempCustomerCommandHandler : IRequestHandler<CreateTempCustomerCommand, Response<TempCustomerDto>>
    {
        private readonly IQueueService _queueService;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTempCustomerCommandHandler> _logger;        

        public CreateTempCustomerCommandHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository, ILogger<CreateTempCustomerCommandHandler> logger, IQueueService queueService)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
            _logger = logger;
            _queueService = queueService;
        }
        public async Task<Response<TempCustomerDto>> Handle(CreateTempCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _tempCustomerRepository.GetTempCustomerByNIN(request.NIN);
            if(customer!=null)
            {
                var resp = new Response<TempCustomerDto>();
                resp.Succeeded = false;
                resp.Message = "The Customer with the given NIN already exist"; 
                return resp;
            }
           
            var tempCustomer = _mapper.Map<TempCustomer>(request);
            tempCustomer = await _tempCustomerRepository.AddAsync(tempCustomer);
            await _queueService.SendMessageAsync<TempCustomer>(tempCustomer, "TempCustomer");
         
            var response = new Response<TempCustomerDto>();
            response.Data = _mapper.Map<TempCustomerDto>(tempCustomer);
            response.Succeeded = true;
            response.Message = "success";
            _logger.LogInformation("Handle Completed");
            return response;
        }
    }
}