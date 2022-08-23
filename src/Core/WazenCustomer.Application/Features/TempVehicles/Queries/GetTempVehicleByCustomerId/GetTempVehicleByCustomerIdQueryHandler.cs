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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId
{
    public class GetTempVehicleByCustomerIdQueryHandler : IRequestHandler<GetTempVehicleByCustomerIdQuery, Response<List<TempVehicleByCustomerIdVm>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempVehicleByCustomerIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, ILogger<GetTempVehicleByCustomerIdQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
        }

        public async Task<Response<List<TempVehicleByCustomerIdVm>>> Handle(GetTempVehicleByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleResponse = new Response<List<TempVehicleByCustomerIdVm>>();
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if(customer!=null)
            {
                var vehicles = _vehicleRepository.GetVehiclesByCustomerID(request.CustomerId);
                if (vehicles.Count == 0)
                {
                    var resposeObject = new Response<List<TempVehicleByCustomerIdVm>>(request.CustomerId + " is not available");
                    return resposeObject;
                }
                var vehiclesDetailDto = _mapper.Map<List<TempVehicleByCustomerIdVm>>(vehicles);
                vehicleResponse = new Response<List<TempVehicleByCustomerIdVm>>(vehiclesDetailDto, "success");                
            }
            var tempCustomer = await _tempCustomerRepository.GetByIdAsync(request.CustomerId);
            if(tempCustomer!=null)
            {
                var tempVehicles = _tempVehicleRepository.GetVehicleByCustomerId(request.CustomerId);
                if (tempVehicles.Count == 0)
                {
                    var resposeObject = new Response<List<TempVehicleByCustomerIdVm>>(request.CustomerId + " is not available");
                    return resposeObject;
                }
                var tempVehiclesDetailDto = _mapper.Map<List<TempVehicleByCustomerIdVm>>(tempVehicles);
                vehicleResponse = new Response<List<TempVehicleByCustomerIdVm>>(tempVehiclesDetailDto, "success");                
            }
            return vehicleResponse;
        }
    }
}