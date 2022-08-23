using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId
{
    public class GetDriverVehicleViolationDetailsByVehicleIdQueryHandler : IRequestHandler<GetDriverVehicleViolationDetailsByVehicleIdQuery, Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDriverVehicleViolationDetailsByVehicleIdQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, IDriverRepository driverRepository, ITempDriverRepository tempDriverRepository, ILogger<GetDriverVehicleViolationDetailsByVehicleIdQueryHandler> logger)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository = tempVehicleRepository;
            _driverRepository = driverRepository;
            _tempDriverRepository = tempDriverRepository;
            _logger = logger;
        }
        public async Task<Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>> Handle(GetDriverVehicleViolationDetailsByVehicleIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            if(vehicle!=null)
            {
                var driver = _driverRepository.GetDriverListByVehicleId(request.VehicleId);
                if(driver.Count==0 || driver==null)
                {
                    var responseEmpty = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>();
                    responseEmpty.Succeeded = true;
                    responseEmpty.Message = "Id is not available";
                    responseEmpty.Data = new List<GetDriverVehicleViolationDetailsByVehicleIdVm>();
                    return responseEmpty;
                }
                var vehiclesDetailDto = _mapper.Map<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(driver);
                var vehicleResponse = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(vehiclesDetailDto, "success");

                return vehicleResponse;
            }
            else
            {
                var tempDriver = _tempDriverRepository.GetDriverListByVehicleId(request.VehicleId);
                if (tempDriver.Count == 0 || tempDriver == null)
                {
                    var responseEmpty = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>();
                    responseEmpty.Succeeded = true;
                    responseEmpty.Message = "Id is not available";
                    responseEmpty.Data = new List<GetDriverVehicleViolationDetailsByVehicleIdVm>();
                    return responseEmpty;
                }

                var tempVehiclesDetailDto = _mapper.Map<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(tempDriver);
                var response = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(tempVehiclesDetailDto, "success");

                return response;
            }

            //var tempData = _tempDriverRepository.GetDriverListByVehicleId(request.VehicleId);   
            //if (tempData.Count == 0 || tempData==null)
            //{
            //    var responseEmpty = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>();
            //    responseEmpty.Succeeded = true;
            //    responseEmpty.Message = "Id is not available";
            //    responseEmpty.Data = new List<GetDriverVehicleViolationDetailsByVehicleIdVm>();
            //    return responseEmpty;
            //}
           
            //var tempVehiclesDetailDto = _mapper.Map<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(tempData);
            //var response = new Response<List<GetDriverVehicleViolationDetailsByVehicleIdVm>>(tempVehiclesDetailDto, "success");
            
            //return response;
        }
    }
}
