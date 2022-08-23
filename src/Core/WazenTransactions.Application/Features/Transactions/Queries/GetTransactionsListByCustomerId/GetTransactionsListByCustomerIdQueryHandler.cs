using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId
{
    public class GetTransactionsListByCustomerIdQueryHandler : IRequestHandler<GetTransactionsListByCustomerIdQuery, Response<List<Transaction>>>
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTransactionsListByCustomerIdQueryHandler(IMapper mapper, ITransactionRepository transactionRepository,IInsuranceCompanyRepository insuranceCompanyRepository,
            ICustomerRepository customerRepository, ICustomerVehicleRepository customerVehicleRepository,
            ILogger<GetTransactionsListByCustomerIdQueryHandler> logger)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
            _customerVehicleRepository = customerVehicleRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _logger = logger;
        }
        public async Task<Response<List<Transaction>>> Handle(GetTransactionsListByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var transaction = _transactionRepository.GetTransactionByCustomerId(request.Id);
            if (transaction == null)
            {
                var resposeObject = new Response<List<Transaction>>(request.Id + " is not available");
                return resposeObject;
            }
            _logger.LogInformation("Handle Compeleted");
            return new Response<List<Transaction>>(transaction, "success");
        }
    }
}
