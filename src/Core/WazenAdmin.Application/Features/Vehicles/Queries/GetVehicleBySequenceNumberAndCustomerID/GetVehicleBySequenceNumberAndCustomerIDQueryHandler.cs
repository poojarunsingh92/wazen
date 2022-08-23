using AutoMapper;
using MediatR;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Infrastructure;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID
{
    public class GetVehicleBySequenceNumberAndCustomerIDQueryHandler : IRequestHandler<GetVehicleBySequenceNumberAndCustomerIDQuery, Response<VehicleBySeqNumAndCustomerIdVm>>
    {
        private readonly IQueueService _queueService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Random _random = new Random();

        public GetVehicleBySequenceNumberAndCustomerIDQueryHandler(ICustomerRepository customerRepository, IVehicleRepository vehicleRepository,  IMapper mapper, IQueueService queueService)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _queueService = queueService;
        }
        public async Task<Response<VehicleBySeqNumAndCustomerIdVm>> Handle(GetVehicleBySequenceNumberAndCustomerIDQuery request, CancellationToken cancellationToken)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string newResponse = "";
            var response = new Response<VehicleBySeqNumAndCustomerIdVm>();

            var customer = await _customerRepository.GetByIdAsync(request.CustomerID);
            if (customer != null)
            {
                RestClient clientCustomerCar = new RestClient("http://180.149.247.134:8097/api/v1/Car/getCarInfoBySequence");
                var requestYakeenGetCustomerCarInfoInfo = new RestRequest(Method.GET);
                requestYakeenGetCustomerCarInfoInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestYakeenGetCustomerCarInfoInfo.AddHeader("Content-Type", "application/json");
                IRestResponse getCustomerCarInfoResponse = clientCustomerCar.Execute(requestYakeenGetCustomerCarInfoInfo);
                if (getCustomerCarInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getCustomerCarInfoResponse.Content;
                }
                var actualCustomerResponse = JsonSerializer.Deserialize<getCarInfoBySequenceVm>(newResponse);

                var customerVehicleNumberDigits = (_random.Next(1111, 9999)).ToString();
                const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var vehicleNumbersAlphabets = new string(Enumerable.Repeat(characters, 3)
                  .Select(s => s[_random.Next(s.Length)]).ToArray());
                var randomCustomerVehicleNumber = customerVehicleNumberDigits + "-" + vehicleNumbersAlphabets;

                ///End CarInfo Code

                Vehicle createVehicleCommand = new Vehicle()
                {
                    VehicleRegistrationExpiryDate = new DateTime(),
                    ParkingGarage = true,
                    IsSelected = true,
                    SequenceNumber = request.SequenceNumber,
                    CustomerID = request.CustomerID,
                    VehiclePlateType = "PlateType",
                    VehiclePlateNumber = actualCustomerResponse.plateNumber,
                    FirstPlateLetter = actualCustomerResponse.plateText1,
                    SecondPlateLetter = actualCustomerResponse.plateText2,
                    ThirdPlateLetter = actualCustomerResponse.plateText3,
                    VehicleMake = actualCustomerResponse.vehicleMaker,
                    VehicleModel = actualCustomerResponse.vehicleModel,
                    VehicleColor = actualCustomerResponse.majorColor,
                    YearofManufacture = actualCustomerResponse.modelYear,
                    VehicleNumber = randomCustomerVehicleNumber
                };
                var vehicleResponse = await _vehicleRepository.AddAsync(createVehicleCommand);

                //var vehicle = await _vehicleRepository.GetVehicleBySequenceNumberAndCustomerID(request.SequenceNumber, request.CustomerID);
                //await _queueService.SendMessageAsync<Vehicle>(vehicleResponse, "Vehicle");
                var vehiclesDetailDto = _mapper.Map<VehicleBySeqNumAndCustomerIdVm>(vehicleResponse);
                response = new Response<VehicleBySeqNumAndCustomerIdVm>(vehiclesDetailDto, "Vehicle added successfully");
            }
            else
            {
                response = new Response<VehicleBySeqNumAndCustomerIdVm>("Customer is not available");
                response.Succeeded = false;
            }
            return response;
        }
    }
}
