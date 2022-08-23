using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
    public class AdminResponse
    {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string designation { get; set; }
        public string password { get; set; }
        public Boolean isActive { get; set; }
        public DateTime date { get; set; }
    }
}
