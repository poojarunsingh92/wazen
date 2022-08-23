using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Response<UpdateCustomerResponse>>
    {
        public Guid CustomerId { get; set; }
        public int? SalutationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIN { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Userid { get; set; }
    }
}
