using MediatR;
using WebApiMediator.Features.Products.DTOs;

namespace WebApiMediator.Features.Products.Queries.List;

public record ListProductsQuery : IRequest<List<ProductDto>>;
