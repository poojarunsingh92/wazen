using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Exceptions;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Response<Guid>>
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionToUpdate = await _transactionRepository.GetByIdAsync(request.Id);

            if (transactionToUpdate == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            _mapper.Map(request, transactionToUpdate, typeof(UpdateTransactionCommand), typeof(Transaction));
            await _transactionRepository.UpdateAsync(transactionToUpdate);

            return new Response<Guid>(request.Id, "Updated successfully ");
        }
    }
}
