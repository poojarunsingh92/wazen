using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates
{
   public class GetTransactionBetweenDatesQuery : IRequest<Response<List<GetTransactionBetweenDatesVm>>>
    {
        public Guid CustomerID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
