using MediatR;
using WebApiMediator.Persistence;

namespace WebApiMediator.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand, Guid?>
{
    public async Task<Guid?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync(request.Id);
        if (product == null) return null;
        context.Products.Update(product);
        await context.SaveChangesAsync();

        return request.Id;
    }
}
