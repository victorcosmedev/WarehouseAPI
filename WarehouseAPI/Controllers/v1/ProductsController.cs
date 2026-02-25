using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.Application.Application.Products.Commands;
using WarehouseAPI.Application.CQRS.Products.Queries;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
