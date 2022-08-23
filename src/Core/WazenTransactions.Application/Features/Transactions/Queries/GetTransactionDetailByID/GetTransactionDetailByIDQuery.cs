using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionDetailByID
{
    public class GetTransactionDetailByIDQuery : IRequest<Response<GetTransactionDetailByIDVm>>
    {
        public Guid ID { get; set; }
    }
}
