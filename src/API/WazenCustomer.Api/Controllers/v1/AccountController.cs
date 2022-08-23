using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.Account.Commands.Register;
using WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail;
using WazenCustomer.Application.Models.Authentication;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        public AccountController(IMediator mediator, ILogger<AccountController> logger, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _customerRepository = customerRepository;
        }

        //Customer Registration
        [HttpPost("register")]
        public async Task<ActionResult<WazenCustomer.Application.Features.Account.Commands.Register.RegistrationResponse>> RegisterAsync(CreateRegistrationRequestCommand request)
        {
            _logger.LogInformation("Register Inititated");
            var dtos = await _mediator.Send(request);
            //if(dtos.Data!=null)
            //{
            //    var sendOTPToCustomerEmailQuery = new SendOTPToCustomerEmailQuery() { Email = dtos.Data.Email };
            //    var response = await _mediator.Send(sendOTPToCustomerEmailQuery);
            //}
            _logger.LogInformation("Register Completed");
            return Ok(dtos);
        }

        //Customer LogIn/Sin\In
        [HttpPost("SignIn", Name = "SignIn")]
        public async Task<ActionResult> SignIn(string Email, string Password)
        {
            _logger.LogInformation("SignIn Inititated");
            var customer = await _customerRepository.GetCustomerByEmail(Email);
            if(customer.IsDelete == true || customer.IsVerified == false || (customer.IsDelete==true && customer.IsVerified==false))
            {
                var response = new Response<bool>();
                response.Succeeded = false;
                response.Message = "This account need to do verify first or do activate or restore it first";
                response.Errors = null;
                response.Data = false;
                return Ok(response);
            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string newResponse = "";

            RestClient client = new RestClient("http://identity.wazen.ml/api/v1/Account/authenticate");

            var requestIdentityRegister = new RestRequest(Method.POST);
            requestIdentityRegister.AddHeader("Content-Type", "application/json");
            var customerLogin = new LoginRequest()
            {
                email = Email,
                password = Password
            };

            var body = JsonSerializer.Serialize(customerLogin);
            requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
            if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                newResponse = getRegisterResponse.Content;
            }
            var actualResponse = JsonSerializer.Deserialize<LoginResponse>(newResponse);
            _logger.LogInformation("SignIn Completed");
            return Ok(actualResponse);
        }


        //private readonly IAuthenticationService _authenticationService;
        //public AccountController(IAuthenticationService authenticationService)
        //{
        //    _authenticationService = authenticationService;
        //}

        //[HttpPost("authenticate")]
        //public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        //{
        //    return Ok(await _authenticationService.AuthenticateAsync(request));
        //}

        //[HttpPost("register")]
        //public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        //{
        //    return Ok(await _authenticationService.RegisterAsync(request));
        //}

        //[HttpPost("refresh-token")]
        //public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        //{
        //    return Ok(await _authenticationService.RefreshTokenAsync(request));
        //}

        //[HttpPost("revoke-token")]
        //public async Task<IActionResult> RevokeTokenAsync(RevokeTokenRequest request)
        //{
        //    var response = await _authenticationService.RevokeToken(request);
        //    if (response.Message == "Token is required")
        //        return BadRequest(response);
        //    else if (response.Message == "Token did not match any users")
        //        return NotFound(response);
        //    else
        //        return Ok(response);
        //}


        [HttpGet("UpdatedOn23August22_12_10AM", Name = "UpdatedOn23August22_12_10AM")]
        public async Task<ActionResult> UpdatedOn23August22_12_10AM()
        {
            return Ok();
        }
    }
}