using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class Salutation : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}