using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionList
{
    public class GetTransactionListQueryHandler : IRequestHandler<GetTransactionListQuery, Response<IEnumerable<TransactionListVm>>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly ITransactionRepository _transactionRepository;
        
        private readonly IMapper _mapper;
        public GetTransactionListQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, IInsuranceCompanyRepository insuranceCompanyRepository, ICustomerRepository customerRepository, ICustomerVehicleRepository customerVehicleRepository )
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _customerRepository = customerRepository;
            _customerVehicleRepository = customerVehicleRepository;
        }
        public async Task<Response<IEnumerable<TransactionListVm>>> Handle(GetTransactionListQuery request, CancellationToken cancellationToken)
        {
            var allTransactions = await _transactionRepository.ListAllAsync();
            var transactionList = _mapper.Map<List<TransactionListVm>>(allTransactions);
            var response = new Response<IEnumerable<TransactionListVm>>(transactionList);
            return response;
        }
    }
}
