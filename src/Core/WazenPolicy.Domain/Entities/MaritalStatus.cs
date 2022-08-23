using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class MaritalStatus : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
    }
}