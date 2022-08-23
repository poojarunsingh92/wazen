using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Wazen.Application.Features.Payment.Command.CreatePaymentCommand;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<Response<string>>
    {
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        //public int PolicyPurchaseType { get; set; }
        //public Guid ICID { get; set; }
        public List<VehicleDto> VehicleList { get; set; }
    }
}
