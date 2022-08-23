using MediatR;
using System;

namespace WazenAdmin.Application.Features.InsuranceCompanies.Commands.DeleteInsuranceCompanies
{
   public class DeleteInsuranceCompaniesCommand : IRequest
    {

        public Guid ID { get; set; }
    }
}
