using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext dbContext, ILogger<Transaction> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        public async Task<Transaction> GetTransactionByCustomerID(Guid CustomerID)
        {
            var transaction = _dbContext.Transactions.FirstOrDefault(x=>x.CustomerId==CustomerID);
            return transaction;
        }
    }
}
