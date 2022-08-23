using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.RolesUser
{
   public class RoleByID
    {
        public string id { get; set; }
        public string name { get; set; }
        public string normalisedName { get; set; }
        public string concurrencyStamp { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public bool? isActive { get; set; }
        public bool? viewPermission { get; set; }
        public bool? writePermission { get; set; }
        public bool? readPermission { get; set; }
    }
}
