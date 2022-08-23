using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand :   IRequest<Response<Guid>>
    {
        public string StatusDsc { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; }

        public string PaymentGatewayResponse { get; set; }

        public decimal IcAmount { get; set; }

        public decimal WpAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string CardNumber { get; set; }

        public string PaymentMethod { get; set; }

        //public Guid? CustomerVehicleId { get; set; }

        //public Guid? ICId { get; set; }

    }
}
