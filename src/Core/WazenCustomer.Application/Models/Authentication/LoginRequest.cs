using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Models.Authentication
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
