using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs
{
    public class CreateAboutUsDto
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
