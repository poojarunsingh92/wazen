using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerId;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID
{
    public class GetVehicleBySequenceNumberAndCustomerIDQueryHandler : IRequestHandler<GetVehicleBySequenceNumberAndCustomerIDQuery, Response<VehicleBySequenceNumberAndCustomerIDVm>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IQueueService _queueService;
        private readonly Random _random = new Random();

        public GetVehicleBySequenceNumberAndCustomerIDQueryHandler(ILogger<GetVehicleBySequenceNumberAndCustomerIDQueryHandler> logger, IMapper mapper, IVehicleRepository vehicleRepository, IQueueService queueService)
        {
            _logger = logger;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _queueService = queueService;
        }
        public async Task<Response<VehicleBySequenceNumberAndCustomerIDVm>> Handle(GetVehicleBySequenceNumberAndCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var vehicleBySequenceNumberAndCustomerID = await _vehicleRepository.GetVehicleBySequenceNumberAndCustomerID(request.SequenceNumber, request.CustomerID);

            if (vehicleBySequenceNumberAndCustomerID != null)
            {
                var resposeObject = new Response<VehicleBySequenceNumberAndCustomerIDVm>("Sequence Number already exist");
                return resposeObject;
            }


            ///CarInfo Code
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string newResponse = "";

            //AzureServer
            //RestClient client = new RestClient("http://180.149.247.134:8097/api/v1/Car/getCarInfoBySequence");

            //Server
            RestClient client = new RestClient("http://180.149.247.134:8097/api/v1/Car/getCarInfoBySequence");
            var requestYakeenGetCarInfoInfo = new RestRequest(Method.GET);
            requestYakeenGetCarInfoInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
            requestYakeenGetCarInfoInfo.AddHeader("Content-Type", "application/json");
            //requestYakeenGetCarInfoInfo.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getCarInfoResponse = client.Execute(requestYakeenGetCarInfoInfo);
            if (getCarInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getCarInfoResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<getVehicleInfoBySequenceVm>(newResponse);

            var vehicleNumberDigits = (_random.Next(1111, 9999)).ToString();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var vehicleNumberAlphabets = new string(Enumerable.Repeat(chars, 3)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
            var randomVehicleNumber = vehicleNumberDigits + "-" + vehicleNumberAlphabets;

            //return actualResponse;
            ///End CarInfo Code

            Vehicle vehicle = new Vehicle()
            {
                //ID = Guid.NewGuid(),
                VehicleRegistrationExpiryDate = new DateTime(),
                //ParkingGarage = "true",
                IsSelected = true,
                SequenceNumber = request.SequenceNumber,
                CustomerID = request.CustomerID,
                VehiclePlateNumber = actualResponse.plateNumber,
                FirstPlateLetter = actualResponse.plateText1,
                SecondPlateLetter = actualResponse.plateText2,
                ThirdPlateLetter = actualResponse.plateText3,
                VehicleMake = actualResponse.vehicleMaker,
                VehicleModel = actualResponse.vehicleModel,
                VehicleColor = actualResponse.majorColor,
                YearofManufacture = actualResponse.modelYear,
                VehicleNumber = randomVehicleNumber
            };
            var vehicleResponse = await _vehicleRepository.AddAsync(vehicle);
            await _queueService.SendMessageAsync<Vehicle>(vehicleResponse, "Vehicle");
            var vehicleDetailDto = _mapper.Map<VehicleBySequenceNumberAndCustomerIDVm>(vehicleResponse);
            var response = new Response<VehicleBySequenceNumberAndCustomerIDVm>(vehicleDetailDto, "Vehicle Added Successfully");
            return response;
        }
    }
}
