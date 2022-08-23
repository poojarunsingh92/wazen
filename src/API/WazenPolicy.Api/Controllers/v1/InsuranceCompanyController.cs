using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;

namespace WazenPolicy.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InsuranceCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public InsuranceCompanyController(IMediator mediator, ILogger<InsuranceCompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //GetInsuranceCompanyList
        [HttpGet("GetInsuranceCompanyList", Name = "GetInsuranceCompanyList")]
        public async Task<ActionResult> GetInsuranceCompanyList()
        {
            _logger.LogInformation("GetInsuranceCompanyList Initiated");
            var getInsuranceCompanyListQuery = new GetInsuranceCompanyListQuery() {};
            var response = await _mediator.Send(getInsuranceCompanyListQuery);
            _logger.LogInformation("GetInsuranceCompanyList Completed");
            return Ok(response);
        }
    }
}
