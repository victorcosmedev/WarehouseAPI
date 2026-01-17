using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Application.Application.Products.Commands;

namespace WarehouseAPI.Presentation.Controllers.v1
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), response);
        }
    }
}
