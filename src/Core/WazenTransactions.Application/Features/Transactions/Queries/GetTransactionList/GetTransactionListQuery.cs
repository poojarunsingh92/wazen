using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionList
{
    public class GetTransactionListQuery : IRequest<Response<IEnumerable<TransactionListVm>>>
    {

    }
}
