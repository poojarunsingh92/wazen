using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Models.Authentication
{
    public class AdminResponse
    {
        public string ID { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}
