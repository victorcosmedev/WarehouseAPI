using MediatR;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Interfaces;

namespace WarehouseAPI.Application.Application.Products.Commands;

public record CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}

public record CreateProductResponse
{
    public Guid ExternalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IRepository<Product> _productRepository;
    public CreateProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateProductResponse();

        var product = new Product(request.Name, request.Description, request.Stock, request.Price);
        var entity = await _productRepository.AddAsync(product);

        response.ExternalId = entity.ExternalId;
        response.Name = entity.Name;
        response.Description = entity.Description;
        response.Stock = entity.Stock;
        response.Price = entity.Price;
        response.Active = entity.Active;

        return response;
    }
}
