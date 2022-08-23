using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Drivers.Queries.GetDriverByVehicleID
{
    public class GetDriverByVehicleIDQueryHandler : IRequestHandler<GetDriverByVehicleIDQuery, Response<DriverByVehicleIDVm>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDriverByVehicleIDQueryHandler(IMapper mapper, IDriverRepository driverRepository, ILogger<GetDriverByVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
            _logger = logger;
        }
        public async Task<Response<DriverByVehicleIDVm>> Handle(GetDriverByVehicleIDQuery request, CancellationToken cancellationToken)
        {

            var driver = await _driverRepository.GetDriverByVehicleID(request.VehicleID);
            if (driver == null)
            {
                var resposeObject = new Response<DriverByVehicleIDVm>(request.VehicleID + " is not available");
                return resposeObject;
            }

            var driverDto = _mapper.Map<DriverByVehicleIDVm>(driver);
            var response = new Response<DriverByVehicleIDVm>(driverDto, "success");
            return response;
        }
    }
}
