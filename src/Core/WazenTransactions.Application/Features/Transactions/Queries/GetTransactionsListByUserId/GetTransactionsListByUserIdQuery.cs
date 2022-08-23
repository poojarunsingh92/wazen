using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId
{
   public class GetTransactionsListByUserIdQuery : IRequest<Response<List<GetTransactionsDto>>>
    {
        public Guid UserId { get; set; }

    }
}
