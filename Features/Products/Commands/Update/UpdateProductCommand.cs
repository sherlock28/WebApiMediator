﻿using MediatR;

namespace WebApiMediator.Features.Products.Commands.Update;

public record UpdateProductCommand(Guid Id, string? Name, string? Description, decimal? Price) : IRequest<Guid?>;
