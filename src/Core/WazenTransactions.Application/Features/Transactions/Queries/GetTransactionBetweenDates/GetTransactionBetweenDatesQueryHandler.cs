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

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates
{
    public class GetTransactionBetweenDatesQueryHandler :
          IRequestHandler<GetTransactionBetweenDatesQuery, Response<List<GetTransactionBetweenDatesVm>>>
    {
        private readonly ILogger<GetTransactionBetweenDatesQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionBetweenDatesQueryHandler(ILogger<GetTransactionBetweenDatesQueryHandler> logger, IMediator mediator, IMapper mapper, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
          
        }
        public async Task<Response<List<GetTransactionBetweenDatesVm>>> Handle(GetTransactionBetweenDatesQuery request, CancellationToken cancellationToken)
        {
            var response = new  Response<List<GetTransactionBetweenDatesVm>>();
            var allTransactions = await _transactionRepository.GetTransactionsByCustomerIDFromToDateAsync(request.CustomerID,request.FromDate,request.ToDate);
            var ViolationTypeList = _mapper.Map<List<GetTransactionBetweenDatesVm>>(allTransactions);
            response.Data = ViolationTypeList;
            response.Succeeded = true;
            response.Message = "Transaction list";
            return response;
        }
    }
}
