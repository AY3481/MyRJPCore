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

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<CustomerController>/customer-transactions/5
        [HttpGet("customer-transactions/{id}")]
        public async Task<IActionResult> GetCustomerTransactions([FromRoute] long id)
            => Ok(await _mediator.Send(new GetCustomerTransactionsQuery(id)));

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestCreateModel customerRequestCreateModel)
            => Ok(await _mediator.Send(new CreateCustomerCommand(customerRequestCreateModel)));

        // POST api/<CustomerController>/create-account
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CustomerAccountRequestCreateModel customerAccountRequestCreateModel)
            => Ok(await _mediator.Send(new CreateCustomerAccountCommand(customerAccountRequestCreateModel)));

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
