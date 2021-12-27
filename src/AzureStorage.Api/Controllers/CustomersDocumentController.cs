using AzureStorage.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureStorage.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CustomersDocumentController : ControllerBase
    {
        private readonly IStorageService _service;
        private readonly IMediator _mediator;

        public CustomersDocumentController(IMediator mediator, IStorageService service)
        {
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index() =>
            Ok(await _service.GetBlobs("personal"));
    }
}
