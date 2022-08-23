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

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId
{
    public class GetTransactionsListByUserIdQueryHandler : IRequestHandler<GetTransactionsListByUserIdQuery, Response<List<GetTransactionsDto>>>
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public GetTransactionsListByUserIdQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, IInsuranceCompanyRepository insuranceCompanyRepository,
           ICustomerRepository customerRepository, ICustomerVehicleRepository customerVehicleRepository,
           ILogger<GetTransactionsListByUserIdQueryHandler> logger)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
            _customerVehicleRepository = customerVehicleRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _logger = logger;
        }

        public async Task<Response<List<GetTransactionsDto>>> Handle(GetTransactionsListByUserIdQuery request, CancellationToken cancellationToken)
        {
            /*var transaction = _transactionRepository.GetTransactionByUserId(request.UserId);
            var transactionsByUserId = _mapper.Map<List<GetTransactionsDto>>(transaction);
            var response = new Response<List<GetTransactionsDto>>(transactionsByUserId, "success");
            return response;*/

            var response = new Response<List<GetTransactionsDto>>();
            return response;
        }
    }
}
