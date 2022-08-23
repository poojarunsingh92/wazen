using WazenAdmin.Domain.Common;
using System;

namespace WazenAdmin.Domain.Entities
{
    public class Role : AuditableEntity
    {
        public Guid ID { get; set; }
        public string RoleName { get; set; }
        public string RoleArabicName { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }      
    }
}
