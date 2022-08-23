using WazenAdmin.Application.Responses;
using MediatR;
using System;

namespace WazenAdmin.Application.Features.HomePageBanners.Commands.UpdateHomePageBanner
{
    public class UpdateHomePageBannerCommand : IRequest<Response<Guid>>
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
