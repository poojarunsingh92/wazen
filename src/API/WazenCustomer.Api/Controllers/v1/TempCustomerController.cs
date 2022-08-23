using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempCustomers.Commands.CreateTempCustomer;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetAllTempCustomers;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteByNINAndDOB;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteVerifyOTP;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByCustomerId;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByNationalId;
using WazenCustomer.Application.Features.TempCustomers.Queries.VerifyOTP;

namespace WazenCustomer.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TempCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TempCustomerController(IMediator mediator, ILogger<TempCustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddTempCustomer")]
        public async Task<ActionResult> Create([FromBody] CreateTempCustomerCommand createTempCustomerCommand)
        {
            var tempCustomerDto = await _mediator.Send(createTempCustomerCommand);
            return Ok(tempCustomerDto);
        }

        [HttpGet("allTempCustomer", Name = "GetAllTempCustomer")]
        public async Task<ActionResult> GetAllTempCustomer()
        {
            var dtos = await _mediator.Send(new GetAllTempCustomerListQuery());
            return Ok(dtos);
        }

        [HttpGet("tempCustomerByCustomerId", Name = "GetTempCustomerByCustomerId")]
        public async Task<ActionResult> GetTempCustomerByCustomerId(Guid Id)
        {
            var getTempCustomerByCustomerIdQuery = new GetTempCustomerByCustomerIdQuery()
            {
                Id = Id
            };
            return Ok(await _mediator.Send(getTempCustomerByCustomerIdQuery));
        }

        [HttpGet("GetTempCustomerByNIN", Name = "GetTempCustomerByNIN")]
        public async Task<ActionResult> GetTempCustomerByNIN(String NIN)
        {
            var getTempCustomerByCustomerIdQuery = new GetTempCustomerByNationalIdQuery()
            {
                NIN = NIN
            };
            return Ok(await _mediator.Send(getTempCustomerByCustomerIdQuery));
        }

        [HttpGet("GetQuoteByNINAndDOB", Name = "GetQuoteByNINAndDOB")]
        public async Task<ActionResult> GetQuoteByNINAndDOB(string NIN, DateTime DateOfBirth)
        {
            var getQuoteByNINAndDOBQuery = new GetQuoteByNINAndDOBQuery()
            {
                NIN = NIN,
                DateOfBirth = DateOfBirth
            };
            return Ok(await _mediator.Send(getQuoteByNINAndDOBQuery));
        }

        [HttpGet("GetQuoteVerifyOTP", Name = "GetQuoteVerifyOTP")]
        public async Task<ActionResult> GetQuoteVerifyOTP(Guid CustomerId, string VerifyCode)
        {
            var getQuoteByOTPQuery = new GetQuoteVerifyOTPQuery()
            {
                CustomerId = CustomerId,
                VerifyCode = VerifyCode
            };
            return Ok(await _mediator.Send(getQuoteByOTPQuery));
        }

        [HttpGet("VerifyOTP", Name = "VerifyOTP")]
        public async Task<ActionResult> VerifyOTP(string Email, string VerifyCode)
        {
            var verifyOTPQuery = new VerifyOTPQuery() {Email=Email, VerifyCode=VerifyCode };
            var response = await _mediator.Send(verifyOTPQuery);
            return Ok(response);
        }
    }
}