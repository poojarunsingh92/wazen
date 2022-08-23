using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId
{
    public class GetTransactionsListByCustomerIdQuery : IRequest<Response<List<Transaction>>>
    {
        public Guid Id { get; set; }

    }
}
