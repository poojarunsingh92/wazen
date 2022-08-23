

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

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetTempDriverById
{
    public class GetTempDriverByIdQueryHandler : IRequestHandler<GetTempDriverByIdQuery, Response<TempDriverDetailVm>>
    {

        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempDriverByIdQueryHandler(IMapper mapper, ITempDriverRepository tempDriverRepository, ILogger<GetTempDriverByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempDriverRepository = tempDriverRepository;
            _logger = logger;
        }
        public async Task<Response<TempDriverDetailVm>> Handle(GetTempDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var tempDriver = await _tempDriverRepository.GetByIdAsync(request.Id);
            if (tempDriver == null)
            {
                var resposeObject = new Response<TempDriverDetailVm>(request.Id + " is not available");
                return resposeObject;
            }

            var tempVehicleDetailDto = _mapper.Map<TempDriverDetailVm>(tempDriver);
            var response = new Response<TempDriverDetailVm>(tempVehicleDetailDto, "success");
            return response;
        }
    }
}

