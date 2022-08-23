using System;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class HomePageBanner: AuditableEntity
    {
        public Guid ID { get; set; }
        public string ImageSource { get; set; }
        public int ProductID { get; set; }
        public Boolean IsActive { get; set; }
    }
}
