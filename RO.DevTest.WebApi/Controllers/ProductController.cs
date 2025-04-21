using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;
using RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;
using RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;
using RO.DevTest.Application.DTOs;

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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto dto) {
        dto.IdProd = id;
        await _mediator.Send(new UpdateProductCommand(dto));
        return Ok(new { Message = "O Produto foi atualizado com sucesso." });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(Guid id) {
        await _mediator.Send(new DeleteProductCommand(id));
        return Ok(new { Message = "O Produto foi removido com sucesso." });
    }
}
