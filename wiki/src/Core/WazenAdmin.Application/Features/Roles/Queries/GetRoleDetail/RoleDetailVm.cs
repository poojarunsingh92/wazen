using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRoleDetail
{
    public class RoleDetailVm
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
