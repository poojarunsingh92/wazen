using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.CustomersOTP.Commands.CreateCustomersOTP
{
    public class CustomersOTPDto
    {
        public Guid ID { get; set; }
        public int VerifyCode { get; set; }
        public string NIN { get; set; }
    }
}
