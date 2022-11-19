using Application.Contracts.Requests;
using Application.UseCases.Commands.CustomerManager;
using Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) => _mediator = mediator;

        // GET api/<CustomerController>/customer-transactions
        [HttpGet("customer-transactions")]
        public async Task<IActionResult> GetCustomerTransactions(CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetCustomerTransactionsQuery(), cancellationToken));

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestCreateModel customerRequestCreateModel, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new CreateCustomerCommand(customerRequestCreateModel), cancellationToken));

        // POST api/<CustomerController>/create-account
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CustomerAccountRequestCreateModel customerAccountRequestCreateModel, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new CreateCustomerAccountCommand(customerAccountRequestCreateModel), cancellationToken));

    }
}
