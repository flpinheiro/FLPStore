using FLPStore.Domain.DTOs.Requests.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FLPStore.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { Id = id };
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetPaginatedProductRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
