using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }
        public string? Status { get; set; }
        public bool? isActive { get; set; }
        public bool? ViewPermission { get; set; }
        public bool? WritePermission { get; set; }
        public bool? ReadPermission { get; set; }
    }
}
