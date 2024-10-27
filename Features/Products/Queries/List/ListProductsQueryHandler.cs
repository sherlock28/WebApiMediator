using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiMediator.Persistence;
using WebApiMediator.Features.Products.DTOs;

namespace WebApiMediator.Features.Products.Queries.List;

public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        return await context.Products
            .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
            .ToListAsync();
    }
}
