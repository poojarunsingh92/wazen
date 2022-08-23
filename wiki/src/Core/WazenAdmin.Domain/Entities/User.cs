using System;
using System.ComponentModel.DataAnnotations.Schema;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid ID { get; set; }
        public Guid? Userid { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }        
        public string VerifyCode { get; set; }
        //public Guid UserId { get; set; }

        //ForeignKey
        //[ForeignKey("RoleType")]
        //public Role Role { get; set; }
    }
}
