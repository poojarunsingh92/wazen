using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Users.Queries.GetUserDetail
{
   public class UserDetailVm
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }
        public Guid RoleType { get; set; }
        public string RoleName { get; set; }
    }
}
