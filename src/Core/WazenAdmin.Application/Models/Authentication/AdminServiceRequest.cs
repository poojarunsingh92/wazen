using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Models.Authentication
{
    public class AdminServiceRequest
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string roleName { get; set; }
    }
}
