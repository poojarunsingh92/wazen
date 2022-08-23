using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.ContactUs.Commands.UpdateContactUs
{
   public class UpdateContactUsCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public string NameOfTheCompany { get; set; }

        public string Address { get; set; }

        public string ContactNo { get; set; }

        public string EmailAddress { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string LinkedIn { get; set; }

        public string WebsiteLink { get; set; }

        public string GoogleLocation { get; set; }
    }
}
