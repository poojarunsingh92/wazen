using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempDrivers.Queries.GetTempDriverDetailByCustomerVehicleID
{
    public class GetTempDriverDetailByCustomerVehicleIDQueryHandler : IRequestHandler<GetTempDriverDetailByCustomerVehicleIDQuery, Response<DriverDetailByCustomerVehicleIDVm>>
    {
        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempDriverDetailByCustomerVehicleIDQueryHandler(IMapper mapper, ITempDriverRepository tempDriverRepository, ILogger<GetTempDriverDetailByCustomerVehicleIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempDriverRepository = tempDriverRepository;
            _logger = logger;
        }
        public async Task<Response<DriverDetailByCustomerVehicleIDVm>> Handle(GetTempDriverDetailByCustomerVehicleIDQuery request, CancellationToken cancellationToken)
        {
            var driver = await _tempDriverRepository.GetTempDriverDetailByCustomerVehicleID(request.CustomerVehicleId);
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
