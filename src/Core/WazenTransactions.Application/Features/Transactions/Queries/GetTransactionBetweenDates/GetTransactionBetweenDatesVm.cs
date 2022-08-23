using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates
{
   public class GetTransactionBetweenDatesVm
    {
        public Guid Id { get; set; }
        public string StatusDsc { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string PaymentGatewayResponse { get; set; }
        public decimal IcAmount { get; set; }
        public decimal WpAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string CardNumber { get; set; }
        public string PaymentMethod { get; set; }
        public Guid CustomerId { get; set; }
        public string ICId { get; set; }

    }
}
