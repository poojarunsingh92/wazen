using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList
{
    public class GetAllListCommandHandler : IRequestHandler<GetAllListCommand, Response<List<GetAllListVM>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAllListCommandHandler(IMapper mapper, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, ILogger<GetAllListCommandHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository = tempVehicleRepository;
            _logger = logger;
        }
        public async Task<Response<List<GetAllListVM>>> Handle(GetAllListCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<List<GetAllListVM>>();
            var customer = await _customerRepository.GetByIdAsync(request.CustomerID);
            if (customer != null)
            {
                var vehicles = _vehicleRepository.GetVehicleDriverVehicleViolationListByCustomerId(request.CustomerID).ToList();
                if (vehicles.Count == 0)
                {
                    //var resposeObject = new Response<List<GetAllListVM>>(request.CustomerID + " is not available");
                    //return resposeObject;
                }
                var vehiclesDetailDto = _mapper.Map<List<GetAllListVM>>(vehicles);
                response = new Response<List<GetAllListVM>>(vehiclesDetailDto, "success");                
            }
            else
            {
                var tempVehicles = _tempVehicleRepository.GetTempVehicleDriverVehicleViolationListByCustomerId(request.CustomerID).ToList();
                if (tempVehicles.Count == 0)
                {
                    //var resposeObject = new Response<List<GetAllListVM>>(request.CustomerID + " is not available");
                    //return resposeObject;
                }
                var tempVehiclesDetailDto = _mapper.Map<List<GetAllListVM>>(tempVehicles);
                response = new Response<List<GetAllListVM>>(tempVehiclesDetailDto, "success");
            }
            return response;
        }
    }
}
