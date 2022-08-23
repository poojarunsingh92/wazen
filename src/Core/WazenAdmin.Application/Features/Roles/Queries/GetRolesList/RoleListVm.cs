using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Roles.Queries.GetRolesList
{

    public class GetAllRoles
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
        public Roles data { get; set; }
    }
    public class Roles
    {
        public List<Role> roles { get; set; }

    }
    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }

        public string normalizedName { get; set; }

        public string concurrencyStamp { get; set; }

        public string description { get; set; }

        public string status { get; set; }

        public Boolean? isActive { get; set; }

        public Boolean? viewPermission { get; set; }

        public Boolean? writePermission { get; set; }

        public Boolean? readPermission { get; set; }
    }
    public class RoleListVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Boolean? isActive { get; set; }

        public Boolean? ViewPermission { get; set; }

        public Boolean? WritePermission { get; set; }

        public Boolean? ReadPermission { get; set; }
    }
}
