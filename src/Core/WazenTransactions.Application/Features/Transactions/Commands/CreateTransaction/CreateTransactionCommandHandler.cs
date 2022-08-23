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

namespace WazenTransactions.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<Guid>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTransactionCommandHandler> _logger;

        public CreateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository, ILogger<CreateTransactionCommandHandler> logger)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }
        public async Task<Response<Guid>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);

            var transaction1 = await _transactionRepository.AddAsync(transaction);

            var response = new Response<Guid>(transaction1.Id, "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
