using AutoMapper;
using MediatR;
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
using WazenCustomer.Application.Features.TempVehicles.Commands.CreateTempVehicle;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleBySequenceNumberAndCustomerId
{
    public class GetTempVehicleBySequenceNumberAndCustomerIdQueryHandler : IRequestHandler<GetTempVehicleBySequenceNumberAndCustomerIdQuery, Response<TempVehicleBySeqNumAndCustomerIdVm>>
    {
        private readonly IQueueService _queueService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempvehicleRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Random _random = new Random();

        public GetTempVehicleBySequenceNumberAndCustomerIdQueryHandler(ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, IVehicleRepository vehicleRepository, ITempVehicleRepository tempvehicleRepository, IMediator mediator, IMapper mapper, IQueueService queueService)
        {
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
            _vehicleRepository = vehicleRepository;
            _tempvehicleRepository = tempvehicleRepository;
            _mediator = mediator;
            _mapper = mapper;
            _queueService = queueService;
        }
        public async Task<Response<TempVehicleBySeqNumAndCustomerIdVm>> Handle(GetTempVehicleBySequenceNumberAndCustomerIdQuery request, CancellationToken cancellationToken)
        {
            //VehicleNumber generation

            var customerVehicleNumberDigits = (_random.Next(1111, 9999)).ToString();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var vehicleNumbersAlphabets = new string(Enumerable.Repeat(characters, 3)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
            var randomCustomerVehicleNumber = customerVehicleNumberDigits + "-" + vehicleNumbersAlphabets;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            string newResponse = "";
            var response = new Response<TempVehicleBySeqNumAndCustomerIdVm>();

            var customer = await _customerRepository.GetByIdAsync(request.CustomerID);
            if(customer!=null)
            {
                var vehicle = await _vehicleRepository.GetVehicleBySequenceNumberAndCustomerID(request.SequenceNumber, request.CustomerID);
                if(vehicle!=null)
                {
                    var resposeObject = new Response<TempVehicleBySeqNumAndCustomerIdVm>(request.SequenceNumber + " Sequence Number already exist");
                    return resposeObject;
                }
                //AzureServer
                RestClient clientCustomerCar = new RestClient("http://thirdparty.wazen.ml/api/v1/Car/getCarInfoBySequence");

                //Server
                //RestClient clientCustomerCar = new RestClient("http://180.149.247.134:8097/api/v1/Car/getCarInfoBySequence");
                var requestYakeenGetCustomerCarInfoInfo = new RestRequest(Method.GET);
                requestYakeenGetCustomerCarInfoInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestYakeenGetCustomerCarInfoInfo.AddHeader("Content-Type", "application/json");
                IRestResponse getCustomerCarInfoResponse = clientCustomerCar.Execute(requestYakeenGetCustomerCarInfoInfo);
                if (getCustomerCarInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getCustomerCarInfoResponse.Content;
                }
                var actualCustomerResponse = JsonSerializer.Deserialize<getCarInfoBySequenceVm>(newResponse);

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
                    VehiclePurposeId = 1,
                    VehicleNumber = randomCustomerVehicleNumber,
                    VehicleUsagePercentage = "100"
                };
                var vehicleResponse = await _vehicleRepository.AddAsync(createVehicleCommand);                
                await _queueService.SendMessageAsync<Vehicle>(vehicleResponse, "Vehicle");
                var vehiclesDetailDto = _mapper.Map<TempVehicleBySeqNumAndCustomerIdVm>(vehicleResponse);
                response = new Response<TempVehicleBySeqNumAndCustomerIdVm>(vehiclesDetailDto, "vehicle added successfully");
            }
            else
            {
                var tempVehicle = await _tempvehicleRepository.GetVehicleBySequenceNumberAndCustomerId(request.SequenceNumber, request.CustomerID);

                if (tempVehicle != null)
                {
                    var resposeObject = new Response<TempVehicleBySeqNumAndCustomerIdVm>(request.SequenceNumber+" Sequence Number already exist");
                    return resposeObject;
                }

                //CarInfo Code
                //AzureServer
                RestClient client = new RestClient("http://thirdparty.wazen.ml/api/v1/Car/getCarInfoBySequence");

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:8097/api/v1/Car/getCarInfoBySequence");
                var requestYakeenGetCarInfoInfo = new RestRequest(Method.GET);
                requestYakeenGetCarInfoInfo.AddHeader("Authorization", "Basic V2F6ZW46ckxnNy9CI3c5cQ==");
                requestYakeenGetCarInfoInfo.AddHeader("Content-Type", "application/json");
                IRestResponse getCarInfoResponse = client.Execute(requestYakeenGetCarInfoInfo);
                if (getCarInfoResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getCarInfoResponse.Content;
                }
                var actualResponse = JsonSerializer.Deserialize<getCarInfoBySequenceVm>(newResponse);

                //var vehicleNumberDigits = (_random.Next(1111, 9999)).ToString();
                //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                //var vehicleNumberAlphabets = new string(Enumerable.Repeat(chars, 3)
                //  .Select(s => s[_random.Next(s.Length)]).ToArray());
                //var randomVehicleNumber = vehicleNumberDigits + "-" + vehicleNumberAlphabets;
                ///End CarInfo Code

                TempVehicle createTempVehicleCommand = new TempVehicle()
                {
                    VehicleRegistrationExpiryDate = new DateTime(),
                    ParkingGarage = true,
                    IsSelected = true,
                    SequenceNumber = request.SequenceNumber,
                    CustomerID = request.CustomerID,
                    VehiclePlateType = "PlateType",
                    VehiclePlateNumber = actualResponse.plateNumber,
                    FirstPlateLetter = actualResponse.plateText1,
                    SecondPlateLetter = actualResponse.plateText2,
                    ThirdPlateLetter = actualResponse.plateText3,
                    VehicleMake = actualResponse.vehicleMaker,
                    VehicleModel = actualResponse.vehicleModel,
                    VehicleColor = actualResponse.majorColor,
                    YearofManufacture = actualResponse.modelYear,
                    VehiclePurposeId = 1,
                    VehicleNumber = randomCustomerVehicleNumber,
                    VehicleUsagePercentage = "100"
                };
                var TempVehicleResponse = await _tempvehicleRepository.AddAsync(createTempVehicleCommand);
                await _queueService.SendMessageAsync<TempVehicle>(TempVehicleResponse, "TempVehicle");
                var tempVehiclesDetailDto = _mapper.Map<TempVehicleBySeqNumAndCustomerIdVm>(TempVehicleResponse);
                response = new Response<TempVehicleBySeqNumAndCustomerIdVm>(tempVehiclesDetailDto, "Vehicle added successfully");
            }
            return response;
        }
    }
}