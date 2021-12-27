using AzureStorage.Application.Core.CustomerDocuments.Commands;
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
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerCreateCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([BindRequired] int id) =>
            Ok(await _mediator.Send(new GetCustomerByIdQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new ListCustomersQuery()));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([BindRequired] int id, CustomerUpdateCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([BindRequired] int id) =>
            Ok(await _mediator.Send(new CustomerRemoveCommand { Id = id }));

        [HttpPost("document")]
        public async Task<IActionResult> PostCustomerDocument([FromForm] CustomerDocumentCreateCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpPut("document/{id:int}")]
        public async Task<IActionResult> UpdateCustomerDocument([BindRequired] int id, CustomerDocumentUpdateCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpDelete("document/{id:int}")]
        public async Task<IActionResult> DeleteCustomerDocument([BindRequired] int id) =>
            Ok(await _mediator.Send(new CustomerDocumentRemoveCommand { Id = id }));
    }
}
