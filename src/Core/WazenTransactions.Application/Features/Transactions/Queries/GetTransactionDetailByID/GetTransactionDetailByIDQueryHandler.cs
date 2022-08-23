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

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionDetailByID
{
    public class GetTransactionDetailByIDQueryHandler : IRequestHandler<GetTransactionDetailByIDQuery, Response<GetTransactionDetailByIDVm>>
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTransactionDetailByIDQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, ILogger<GetTransactionDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<Response<GetTransactionDetailByIDVm>> Handle(GetTransactionDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.ID);
            if (transaction == null)
            {
                var resposeObject = new Response<GetTransactionDetailByIDVm>(request.ID + " is not available");
                return resposeObject;
            }

            var transactionDetailDto = _mapper.Map<GetTransactionDetailByIDVm>(transaction);
            var response = new Response<GetTransactionDetailByIDVm>(transactionDetailDto, "success");
            return response;
        }
    }
}
