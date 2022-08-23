using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail
{
    public class SendOTPMailToCustomerVm
    {
        public Boolean succeeded { get; set; }
        public string message { get; set; }
        public string? errors { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public bool isSent { get; set; }
        public string verifyCode { get; set; }
    }
}
