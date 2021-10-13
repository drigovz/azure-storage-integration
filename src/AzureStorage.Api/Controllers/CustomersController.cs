using AzureStorage.Application.Core.Customers.Commands;
using AzureStorage.Application.Core.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AzureStorage.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerCreateCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([BindRequired] int id) =>
            Ok(await _mediator.Send(new GetCustomerByIdQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetCustomersQuery()));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([BindRequired] int id, CustomerUpdateCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([BindRequired] int id) =>
            Ok(await _mediator.Send(new CustomerRemoveCommand { Id = id }));
    }
}
