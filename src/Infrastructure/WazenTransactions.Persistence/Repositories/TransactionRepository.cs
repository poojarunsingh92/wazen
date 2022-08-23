using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TransactionRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<Transaction> logger) : base(dbContext, logger)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public List<Transaction> GetTransactionByCustomerId(Guid id)
        {
            var response = _dbContext.Transactions.Where(x => x.CustomerId == id).ToList();
            return response;
        }

        public async Task<IEnumerable<GetTransactionBetweenDatesVm>> GetTransactionsByCustomerIDFromToDateAsync(Guid CustomerID, DateTime FromDate, DateTime ToDate)
        {
            if(FromDate.ToShortDateString()==ToDate.ToShortDateString())
            {
                var transactionList = _dbContext.Transactions.Where(s => s.CustomerId == CustomerID && s.TransactionDate.Date== FromDate).ToList();
                var transactionResponse = _mapper.Map<IEnumerable<GetTransactionBetweenDatesVm>>(transactionList);
                return transactionResponse;
            }
            var transactionsList = _dbContext.Transactions.Where(s => s.CustomerId == CustomerID && (s.TransactionDate >= FromDate && s.TransactionDate <= ToDate)).ToList();
            var response = _mapper.Map<IEnumerable<GetTransactionBetweenDatesVm>>(transactionsList);
            return response;
        }


        /*
        List<GetTransactionDto> ITransactionRepository.GetList()
        {
            var transactionList = _db.Set<Transaction>()
                   .Include(x => x.InsuranceCompany)
                   .Include(x => x.CustomerVehicle).Include(x => x.CustomerVehicle.Customer).Select(x => new GetTransactionDto
                   {
                       EnglishFirstName = x.CustomerVehicle.Customer.EnglishFirstName,
                       EnglishLastName = x.CustomerVehicle.Customer.EnglishLastName,
                       VehicleRegistrationNumber = x.CustomerVehicle.VehicleRegistrationNumber,
                       Id = x.Id,
                       TransactionDate = x.TransactionDate,
                       TotalAmount = x.TotalAmount,
                       StatusDsc = x.StatusDsc
                   });

            return (List<GetTransactionDto>)transactionList;
        }

        
        List<TransactionDetailVm> ITransactionRepository.GetTransactionByCustomerId(Guid id)
        {
            //var CustomerTransacation = _db.Set<CustomerVehicle>().Where(x => x.CustomerId == id)
            //                            .Include(x => x.Customer).Include(x => x.Transactions)
            //                            .Select(x => new TransactionDetailVm
            //                            {
            //                                Id = x.Id,
            //                                VehicleRegistrationNumber = x.VehicleRegistrationNumber,
            //                                EnglishFirstName = x.Customer.EnglishFirstName,
            //                                EnglishLastName = x.Customer.EnglishLastName,
            //                                Transactions = x.Transactions.Where(x => x.CustomerVehicleId == id).ToList()

            //                            });


            var transactions = _db.Set<Transaction>()
                  .Include(x => x.CustomerVehicle).Include(x => x.CustomerVehicle.Customer).Where(x => x.CustomerVehicle.CustomerId == id).Select(x => new TransactionDetailVm
                  {
                      Id = x.Id,
                      StatusDsc = x.StatusDsc,
                      TransactionDate = x.TransactionDate,
                      TotalAmount = x.TotalAmount,
                      VehicleRegistrationNumber = x.CustomerVehicle.VehicleRegistrationNumber,
                      EnglishFirstName = x.CustomerVehicle.Customer.EnglishFirstName,
                      EnglishLastName = x.CustomerVehicle.Customer.EnglishLastName

                  }).ToList();
            return transactions;
        }        

        
        List<GetTransactionsDto> ITransactionRepository.GetTransactionByUserId(Guid id)
        {
            var transactions = _db.Set<Transaction>()
                  .Include(x => x.CustomerVehicle).Include(x => x.CustomerVehicle.Customer).Where(x => x.CustomerVehicle.Customer.UserId == id)
                  .Select(x => new GetTransactionsDto
                  {
                      Id = x.Id,
                      StatusDsc = x.StatusDsc,
                      TransactionDate = x.TransactionDate,
                      TotalAmount = x.TotalAmount,
                      VehicleRegistrationNumber = x.CustomerVehicle.VehicleRegistrationNumber,
                      EnglishFirstName = x.CustomerVehicle.Customer.EnglishFirstName,
                      EnglishLastName = x.CustomerVehicle.Customer.EnglishLastName

                  }).ToList();
            return transactions;
        }
        */
    }
}