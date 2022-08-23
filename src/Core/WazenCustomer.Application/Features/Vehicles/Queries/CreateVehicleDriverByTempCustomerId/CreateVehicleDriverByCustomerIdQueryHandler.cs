using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.Vehicles.Queries.CreateVehicleDriverByTempCustomerId
{
    public class CreateVehicleDriverByCustomerIdQueryHandler : IRequestHandler<CreateVehicleDriverByCustomerIdQuery, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IQueueService _queueService;

        public CreateVehicleDriverByCustomerIdQueryHandler(IMapper mapper, IQueueService queueService , ITempVehicleRepository tempVehicleRepository, IVehicleRepository vehicleRepository, ITempVehicleViolationRepository tempVehicleViolationRepository, IVehicleViolationRepository vehicleViolationRepository, ICustomerVehicleRepository customerVehicleRepository, ITempDriverRepository tempDriverRepository, IDriverRepository driverRepository)
        {
            _mapper = mapper;
            _queueService = queueService;
            _tempVehicleRepository = tempVehicleRepository;
            _vehicleRepository = vehicleRepository;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _vehicleViolationRepository= vehicleViolationRepository;
            _customerVehicleRepository = customerVehicleRepository;
            _tempDriverRepository = tempDriverRepository;
            _driverRepository = driverRepository;
        }

        public async Task<Response<string>> Handle(CreateVehicleDriverByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            int flag = 0;
            var response = new Response<string>();
            var vehicleList = await _tempVehicleRepository.GetVehicleListByCustomerId(request.TempCustomerID);
                     
            foreach(var vehicle in vehicleList)
            {  
                //Shifting data from TempVehicle to Vehicle
                var vehicleDetail = _mapper.Map<Vehicle>(vehicle);
                vehicleDetail.CustomerID = request.CustomerId;
                var vehicleResponse = await _vehicleRepository.AddAsync(vehicleDetail);
                await _queueService.SendMessageAsync<Vehicle>(vehicleResponse, "Vehicle");


                //Shifting data from tempVehicleViolation to VehicleViolation and also sending through Kafka Service
                var vehicleViolationList = await _tempVehicleViolationRepository.GetTempVehicleViolationsByVehicleID(vehicle.ID);
                
                foreach(var vehicleViolation in vehicleViolationList)
                {
                    var vehicleViolationDetail = _mapper.Map<VehicleViolation>(vehicleViolation);
                    vehicleViolationDetail.VehicleID = vehicleResponse.ID;
                    var vehicleViolationResponse = await _vehicleViolationRepository.AddAsync(vehicleViolationDetail);
                    await _queueService.SendMessageAsync<VehicleViolation>(vehicleViolationResponse, "VehicleViolation");
                }

                //Adding entries into the CustomerVehicle and also sending through Kafka Service
                var customerVehicle = new CustomerVehicle() { 
                    CustomerID = request.CustomerId, 
                    VehicleID = vehicle.ID, 
                    StartDate = DateTime.Now, 
                    EndDate = DateTime.Now.AddYears(1) 
                };
                var customerVehicleResponse = await _customerVehicleRepository.AddAsync(customerVehicle);
                await _queueService.SendMessageAsync<CustomerVehicle>(customerVehicleResponse, "CustomerVehicle");


                //Shifting data from tempDriver to Driver and also sending through Kafka Service
                var driver = await _tempDriverRepository.GetTempDriverByVehicleId(vehicle.ID);                
                var driverDetail = _mapper.Map<Driver>(driver);
                driverDetail.CustomerVehicleId = vehicleResponse.ID;
                var driverResponse = await _driverRepository.AddAsync(driverDetail);
                await _queueService.SendMessageAsync<Driver>(driverResponse, "Driver");

                flag = 1;
            }
            if(flag==1)
            {
                response.Message = "Details moved from Temp to Main as TempCustomer become Customer Now";
                response.Succeeded = true;
            }
            else
            {
                response.Message = "Invalid Input Parameters! Please Enter Valid Parameters";
                response.Succeeded = false;
            }
            return response;
        }
    }
}