using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.CreateHomePageBanner
{
    public class CreateHomePageBannerDto
    {
        public Guid ID { get; set; }
        public string ImageSource { get; set; }
        public int ProductID { get; set; }
        public Boolean IsActive { get; set; }
    }
}
