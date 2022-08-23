using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.HomePageBanners.Queries.GetHomePageBannersList
{
    public class HomePageBannerListVm
    {
        public Guid ID { get; set; }
        public string ImageSource { get; set; }
        public int ProductID { get; set; }
        public Boolean IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
