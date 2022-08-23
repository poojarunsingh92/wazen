using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.AboutUs.Commands.CreateAboutUs
{
    public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, Response<CreateAboutUsDto>>
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly IMapper _mapper;

        public CreateAboutUsCommandHandler(IMapper mapper, IAboutUsRepository aboutUsRepository)
        {
            _mapper = mapper;
            _aboutUsRepository = aboutUsRepository;
        }

        public async Task<Response<CreateAboutUsDto>> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var createAboutUsCommandResponse = new Response<CreateAboutUsDto>();

            var validator = new CreateAboutUsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAboutUsCommandResponse.Succeeded = false;
                createAboutUsCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAboutUsCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var aboutus = new WazenAdmin.Domain.Entities.AboutUs()
                {
                    Content = request.Content,
                    Description = request.Description
                };
                aboutus = await _aboutUsRepository.AddAsync(aboutus);
                createAboutUsCommandResponse.Data = _mapper.Map<CreateAboutUsDto>(aboutus);
                createAboutUsCommandResponse.Succeeded = true;
                createAboutUsCommandResponse.Message = "success";
            }

            return createAboutUsCommandResponse;
        }
    }
}

