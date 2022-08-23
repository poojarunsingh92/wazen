using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.RolesUser
{
   public class RolesRequest
    {

        public string Name { get; set; }

        //public string NormalizedName { get; set; }

        //public string ConcurrencyStamp { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Boolean isActive { get; set; }

        public Boolean ViewPermission { get; set; }

        public Boolean WritePermission { get; set; }

        public Boolean ReadPermission { get; set; }

    }
}
