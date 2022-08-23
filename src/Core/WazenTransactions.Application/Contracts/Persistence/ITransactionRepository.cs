using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        //List<GetTransactionDto> GetList();

        List<Transaction> GetTransactionByCustomerId(Guid id);

        //List<GetTransactionsDto> GetTransactionByUserId(Guid id);
        Task<IEnumerable<GetTransactionBetweenDatesVm>> GetTransactionsByCustomerIDFromToDateAsync(Guid CustomerID, DateTime form, DateTime to);
    }
}
