using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.Roles.Commands.UpdateRole
{
    public class RoleResponse
    {
        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
        public UpdateRolesResponse data { get; set; }
    }
    public class UpdateRolesResponse
    {
        public string name { get; set; }

        public string normalizedName { get; set; }

        //public string concurrencyStamp { get; set; }

        public string? description { get; set; }

        public string? status { get; set; }

        public Boolean? isActive { get; set; }

        public Boolean? viewPermission { get; set; }

        public Boolean? writePermission { get; set; }

        public Boolean? readPermission { get; set; }
    }

}
