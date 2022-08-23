using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Models.Mail;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.SendMailToCustomer.Queries.SendMail
{
    public class SendOTPToCustomerQueryHandler : IRequestHandler<SendOTPToCustomerQuery, Response<SendOTPToCustomerVm>>
    {
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public SendOTPToCustomerQueryHandler(IEmailService emailService, ILogger<SendOTPToCustomerQueryHandler> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<SendOTPToCustomerVm>> Handle(SendOTPToCustomerQuery request, CancellationToken cancellationToken)
        {
            Email email = new Email() { To = request.To, Body = request.OTP, Subject = request.Subject };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing failed due to an error with the mail service: {ex.Message}");
                throw new NotFoundException("Mailing failed due to an error with the mail service:", ex.Message.ToString());
            }
            var resp = new SendOTPToCustomerVm() { IsSent = true };
            var response = new Response<SendOTPToCustomerVm>(resp, "success");
            response.Succeeded = true;
            response.Message = "success";
            return response;
        }
    }
}
