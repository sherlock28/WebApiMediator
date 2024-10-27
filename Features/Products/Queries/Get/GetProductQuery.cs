using MediatR;
using WebApiMediator.Features.Products.DTOs;

namespace WebApiMediator.Features.Products.Queries.Get;

public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
