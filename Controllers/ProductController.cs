using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiMediator.Features.Products.Queries.Get;
using WebApiMediator.Features.Products.Queries.List;
using WebApiMediator.Features.Products.Commands.Create;
using WebApiMediator.Features.Products.Commands.Delete;
using WebApiMediator.Features.Products.Commands.Update;
using WebApiMediator.Features.Products.Notifications;

namespace WebApiMediator.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:guid}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductById(Guid id, [FromServices] ISender mediatr)
    {
        var product = await mediatr.Send(new GetProductQuery(id));
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("", Name = "GetProductsList")]
    public async Task<IActionResult> GetProductsList([FromServices] ISender mediatr)
    {
        var products = await mediatr.Send(new ListProductsQuery());
        return Ok(products);
    }

    [HttpPost("", Name = "CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command, [FromServices] IMediator mediatr)
    {
        var productId = await mediatr.Send(command);
        if (Guid.Empty == productId) return BadRequest();
		await mediatr.Publish(new ProductCreatedNotification(productId));
        return Created($"/products/{productId}", new { id = productId });
    }

    [HttpDelete("", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid id, [FromServices] ISender mediatr)
    {
        await mediatr.Send(new DeleteProductCommand(id));
        return NoContent();
    }

    [HttpPut("", Name = "UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command, [FromServices] ISender mediatr)
    {
        var productId = await mediatr.Send(command);
        if (productId == null) return NotFound();
        return Ok(new { id = productId });
    }
}
