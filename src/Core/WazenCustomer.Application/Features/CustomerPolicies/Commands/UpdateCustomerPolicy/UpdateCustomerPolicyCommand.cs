using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CustomerPolicies.Commands.UpdateCustomerPolicy
{
   public class UpdateCustomerPolicyCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
        public Guid? CustomerVehicleId { get; set; }         //FK
        public Guid TransactionId { get; set; }
        public Guid? ICID { get; set; }                      //FK
        public int? PolicyTypeId { get; set; }               //FK
        public string PremiumDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public string PolicyNumber { get; set; }
        public string Status { get; set; }
    }
}
