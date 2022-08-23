using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID
{
    public class GetDriverDetailByCustomerVehicleIDQueryHandler : IRequestHandler<GetDriverDetailByCustomerVehicleIDQuery, Response<DriverDetailByCustomerVehicleIDVm>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDriverDetailByCustomerVehicleIDQueryHandler(IMapper mapper, IDriverRepository driverRepository, ILogger<GetDriverDetailByCustomerVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
            _logger = logger;
        }
        public async Task<Response<DriverDetailByCustomerVehicleIDVm>> Handle(GetDriverDetailByCustomerVehicleIDQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetDriverDetailByCustomerVehicleID(request.CustomerVehicleId);
            if (driver == null)
            {
                var resposeObject = new Response<DriverDetailByCustomerVehicleIDVm>(request.CustomerVehicleId + " is not available");
                return resposeObject;
            }

            var driverDto = _mapper.Map<DriverDetailByCustomerVehicleIDVm>(driver);
            var response = new Response<DriverDetailByCustomerVehicleIDVm>(driverDto, "success");
            return response;
        }
    }
}
