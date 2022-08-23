using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Commands.DeleteAboutUs
{
    public class DeleteAboutUsCommandHandler : IRequestHandler<DeleteAboutUsCommand, Response<bool>>
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteAboutUsCommandHandler(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

        public async Task<Response<bool>> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var aboutUsToDelete = await _aboutUsRepository.GetByIdAsync(request.ID);

            if (aboutUsToDelete == null)
            {
                throw new NotFoundException(nameof(AboutUs), request.ID);
            }
            await _aboutUsRepository.DeleteAsync(aboutUsToDelete);
            return new Response<bool>(true, "Record deleted");
        }
    }

}

