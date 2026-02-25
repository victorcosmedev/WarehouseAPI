using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Interfaces;

namespace WarehouseAPI.Application.CQRS.Products.Queries;

public record GetAllProductsQuery : IRequest<GetAllProductsResponse>
{

}

public record GetAllProductsResponse
{

}

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResponse>
{
    private readonly IRepository<Product> _productsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsQueryHandler(IRepository<Product> productsRepository, IUnitOfWork unitOfWork)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetAllProductsResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _productsRepository.GetAllAsync();


    }
}
