using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazenTransactions.Application.Features.Transactions.Commands.CreateTransaction;
using WazenTransactions.Application.Features.Transactions.Commands.UpdateTransaction;
using WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionList;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionDetailByID;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates;

namespace WazenTransactions.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TransactionController(IMediator mediator, ILogger<TransactionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddTransaction")]
        public async Task<ActionResult> Create([FromBody] CreateTransactionCommand createTransactionCommand)
        {
            var id = await _mediator.Send(createTransactionCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateTransaction")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTransactionCommand updateTransactionCommand)
        {
            var response = await _mediator.Send(updateTransactionCommand);
            return Ok(response);
        }

        [HttpGet("GetCustomerVehiclesTransactionList", Name = "GetCustomerVehiclesTransactionList")]
        public async Task<ActionResult> GetCustomerVehiclesTransactionList()
        {
            var dtos = await _mediator.Send(new GetCustomerVehiclesTransactionListQuery()); 
            return Ok(dtos);
        }
       
        [HttpGet("GetTransactionList", Name = "GetTransactionList")]
        public async Task<ActionResult> GetTransactionList()
        {
            var dtos = await _mediator.Send(new GetTransactionListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetTransactionDetailByID/{ID}", Name = "GetTransactionDetailByID")]
        public async Task<ActionResult> GetTransactionDetailByID(Guid ID)
        {
            var getTransferRequestByIdQuery = new GetTransactionDetailByIDQuery() { ID = ID };
            var response = await _mediator.Send(getTransferRequestByIdQuery);
            return Ok(response);
        }

        [HttpGet("GetTransactionByCustomerId", Name = "GetTransactionByCustomerId")]
        public async Task<ActionResult> GetTransactionByCustomerId(Guid Id)
        {
            var getTransferRequestByIdQuery = new GetTransactionsListByCustomerIdQuery() { 
                Id= Id };
            return Ok(await _mediator.Send(getTransferRequestByIdQuery));
        }

        [HttpGet("GetTransactionByUserId", Name = "GetTransactionByUserId")]
        public async Task<ActionResult> GetTransactionByUserId(Guid Id)
        {
            var getTransactionsListByUserIdQuery= new GetTransactionsListByUserIdQuery()
            {
                UserId = Id
            };
            return Ok(await _mediator.Send(getTransactionsListByUserIdQuery));
        }

        [HttpGet("GetTransactionsBetweenDates", Name = "GetTransactionsBetweenDates")]
        public async Task<ActionResult> GetTransactionsBetweenDates(Guid CustomerID, DateTime FromDate, DateTime ToDate)
        {
            var getTransactionBetweenDatesQuery = new GetTransactionBetweenDatesQuery()
            {
                CustomerID = CustomerID,
                FromDate = FromDate,
                ToDate = ToDate
            };
            return Ok(await _mediator.Send(getTransactionBetweenDatesQuery));
        }
    }
}
