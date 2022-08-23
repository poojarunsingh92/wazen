using AutoMapper;
using MediatR;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<UpdateCustomerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IQueueService _queueService;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, IQueueService queueService, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _queueService = queueService;
            _customerRepository = customerRepository;
        }

        public async Task<Response<UpdateCustomerResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            //var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerId);

            //if (customerToUpdate == null)
            //{
            //    var resposeObject = new Response<Guid>(request.CustomerId + " is not available");

            //}

            //_mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));
            //await _customerRepository.UpdateAsync(customerToUpdate);


            var updateCustomerCommandResponse = new Response<UpdateCustomerResponse>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/UpdateEmail");

            var requestIdentityRegister = new RestRequest(Method.PUT);
            requestIdentityRegister.AddHeader("Content-Type", "application/json");


            var customerRequest = new UpdateCustomerCommand()
            {
                CustomerId = request.CustomerId,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NIN = request.NIN,
                Mobile = request.Mobile,
                SalutationId = request.SalutationId,
                Userid = request.Userid


            };
            var body = JsonSerializer.Serialize(customerRequest);
            requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<CustomerResponse>(newResponse);


            UpdateCustomerResponse updateCustomerResponse = new UpdateCustomerResponse()
            {
                userid = request.Userid,

                firstName = actualResponse.data.firstName,
                lastName = actualResponse.data.lastName,
                nIN = request.NIN,
                email = actualResponse.data.email,
                mobile = request.Mobile,
                salutationId = request.SalutationId,
                customerId = request.CustomerId

            };

            var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerId);


            customerToUpdate.SalutationId = request.SalutationId;
            customerToUpdate.ID = request.CustomerId;
            customerToUpdate.NIN = request.NIN;
            customerToUpdate.EnglishFirstName = request.FirstName;
            customerToUpdate.EnglishLastName = request.LastName;
            customerToUpdate.Email = request.Email;
            customerToUpdate.Mobile = request.Mobile;
            customerToUpdate.userId = Guid.Parse(request.Userid);

            await _customerRepository.UpdateAsync(customerToUpdate);
            await _queueService.SendMessageAsync<Customer>(customerToUpdate, "Customer");
            updateCustomerCommandResponse.Succeeded = actualResponse.succeeded;
            updateCustomerCommandResponse.Message = actualResponse.message;
            updateCustomerCommandResponse.Errors = actualResponse.errors;
            updateCustomerCommandResponse.Data = updateCustomerResponse;

            return updateCustomerCommandResponse;

        }
    }
}
