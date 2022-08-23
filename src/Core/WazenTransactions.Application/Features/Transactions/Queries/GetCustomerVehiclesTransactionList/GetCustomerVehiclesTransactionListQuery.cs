using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList
{
    public class GetCustomerVehiclesTransactionListQuery : IRequest<Response<List<GetTransactionDto>>>
    {

    }
}
