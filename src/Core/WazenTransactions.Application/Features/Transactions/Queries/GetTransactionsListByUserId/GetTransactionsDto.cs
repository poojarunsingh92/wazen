using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId
{
  public  class GetTransactionsDto
    {
        public Guid Id { get; set; }

        public string StatusDsc { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal TotalAmount { get; set; }

        public Guid CustomerVehicleId { get; set; }

        public Guid ICId { get; set; }

        public Guid UserId { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string EnglishFirstName { get; set; }

        public string EnglishLastName { get; set; }

    }
}
