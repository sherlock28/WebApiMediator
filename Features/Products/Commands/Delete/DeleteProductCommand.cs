using MediatR;

namespace WebApiMediator.Features.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest;
