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

namespace WazenAdmin.Application.Features.FAQ.Commands.DeleteFAQ
{
    public class DeleteFAQCommandHandler : IRequestHandler<DeleteFAQCommand, Response<bool>>
    {
        private readonly IFAQRepository _faqRepsitory;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteFAQCommandHandler(IFAQRepository faqRepsitory)
        {
            _faqRepsitory = faqRepsitory;           
        }

        public async Task<Response<bool>> Handle(DeleteFAQCommand request, CancellationToken cancellationToken)
        {
            var faqToDelete = await _faqRepsitory.GetByIdAsync(request.ID);

            if (faqToDelete == null)
            {
                throw new NotFoundException(nameof(FAQ), request.ID);
            }
            await _faqRepsitory.DeleteAsync(faqToDelete);
            return new Response<bool>(true, "Record deleted");
        }
    }

}
