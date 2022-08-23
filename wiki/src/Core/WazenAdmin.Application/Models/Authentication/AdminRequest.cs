using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Models.Authentication
{
    public class AdminRequest
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public string RoleName { get; set; }
    }
}
