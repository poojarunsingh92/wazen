using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList
{
  public class GetCustomerVehiclesTransactionListQueryHandler : 
        IRequestHandler<GetCustomerVehiclesTransactionListQuery, Response<List<GetTransactionDto>>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
       
        public GetCustomerVehiclesTransactionListQueryHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, IInsuranceCompanyRepository insuranceCompanyRepository, ICustomerRepository customerRepository, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _customerVehicleRepository = customerVehicleRepository;
            _customerRepository = customerRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<Response<List<GetTransactionDto>>> Handle(GetCustomerVehiclesTransactionListQuery request, CancellationToken cancellationToken)
        {
            /*var list = _transactionRepository.GetList();
            
            Console.WriteLine("Completed");
            var transactions = _mapper.Map<List<GetTransactionDto>>(list);

            var response = new Response<List<GetTransactionDto>>(transactions);
            return response;*/
            var response = new Response<List<GetTransactionDto>>();
            return response;
        }
    }
}
