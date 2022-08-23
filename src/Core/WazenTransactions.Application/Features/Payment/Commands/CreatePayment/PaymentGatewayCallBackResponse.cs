using System;
using System.Collections.Generic;
using System.Text;

namespace WazenTransactions.Application.Features.Payment.Commands.CreatePayment
{
    public class PaymentGatewayCallBackResponse
    {
        public string StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public int Amount { get; set; }

        public int CurrencyISOCode { get; set; }

        public string MerchantID { get; set; }

        public string TransactionID { get; set; }

        public string MessageID { get; set; }

        public string SecureHash { get; set; }
    }
}
