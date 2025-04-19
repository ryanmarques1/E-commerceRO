using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/product")]
[OpenApiTags("Products")]
public class ProductController(IMediator mediator) : Controller {
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request) {
        CreateProductResult response = await _mediator.Send(request);
        return Created(HttpContext.Request.GetDisplayUrl(), response);
    }
}
