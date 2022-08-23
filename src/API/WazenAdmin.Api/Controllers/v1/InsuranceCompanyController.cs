using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WazenAdmin.Application.Features.InsuranceCompanies.Commands.CreateInsuranceCompanies;
using Microsoft.AspNetCore.Http;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesDetail;
using WazenAdmin.Application.Features.InsuranceCompanies.Commands.UpdateInsuranceCompanies;
using WazenAdmin.Application.Features.InsuranceCompanies.Commands.DeleteInsuranceCompanies;
using System;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;
using WazenAdmin.Application.Features.InsuranceCompanies.Queries.GetInsuranceComapniesNameList;

namespace WazenAdmin.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InsuranceCompanyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public InsuranceCompanyController(IMediator mediator, ILogger<InsuranceCompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllInsuranceCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllStudents()
        {
            _logger.LogInformation("GetAll Insurance Companies Initiated");
            var dtos = await _mediator.Send(new GetInsuranceCompaniesListQuery());
            _logger.LogInformation("GetAll Insurance Companies Completed");
            return Ok(dtos);
        }


        [HttpPost(Name = "AddInsuranceCompanies")]
        public async Task<ActionResult> Create([FromBody] CreateInsuranceCompaniesCommand createInsuranceCompaniesCommand)
        {
            _logger.LogInformation("Add Insurance Companies Initiated");
            var response = await _mediator.Send(createInsuranceCompaniesCommand);
            _logger.LogInformation("Add Insurance Companies Completed");
            return Ok(response);
        }

        [HttpPut(Name = "UpdateInsuranceCompanies")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateInsuranceCompaniesCommand updateInsuranceCompaniesCommand)
        {
            _logger.LogInformation("Update Insurance Companies Initiated");
            var response = await _mediator.Send(updateInsuranceCompaniesCommand);
            _logger.LogInformation("Update Insurance Companies Completed");
            return Ok(response);
        }

        [HttpDelete("{ID}", Name = "DeleteInsuranceCompanies")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid ID)
        {
            var deleteStudentCommand = new DeleteInsuranceCompaniesCommand() { ID = ID };
            _logger.LogInformation("Delete Insurance Companies Initiated");
            var del = await _mediator.Send(deleteStudentCommand);
            _logger.LogInformation("Delete Insurance Companies Completed");
            return Ok(del);
        }

        [HttpGet("{ID}", Name = "GetInsuranceCompaniesById")]
        public async Task<ActionResult> GetInsuranceCompaniesById(Guid ID)
        {
            _logger.LogInformation("GetInsuranceCompaniesById Initiated");
            var getInsuranceCompaniesDetailQuery = new GetInsuranceCompaniesDetailQuery() { ID = ID };
            _logger.LogInformation("GetInsuranceCompaniesById Initiated");
            return Ok(await _mediator.Send(getInsuranceCompaniesDetailQuery));
        }

        [HttpGet("GetAllInsuranceCompaniesNames", Name = "GetAllInsuranceCompaniesNames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllInsuranceCompaniesNames()
        {
            _logger.LogInformation("GetAll Insurance Companies Names Initiated");
            var dtos = await _mediator.Send(new GetInsuranceCompaniesNameListQuery());
            _logger.LogInformation("GetAll Insurance Companies Names Completed");
            return Ok(dtos);
        }
    }
}
