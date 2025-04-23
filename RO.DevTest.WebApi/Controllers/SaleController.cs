using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Sale.Queries;
using RO.DevTest.Application.Features.Sale.Commands.CreateSaleCommand;
using RO.DevTest.Application.Features.Sale.Commands.DeleteSaleCommand;
using RO.DevTest.Application.Features.Sale.Commands.UpdateSaleCommand;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.WebApi.Controllers;

[Route("api/sale")]
[OpenApiTags("Sales")]
public class SaleController(IMediator mediator) : Controller {
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(CreateSaleResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreateSaleResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateSaleCommand request) {
        CreateSaleResult response = await _mediator.Send(request);
        return Created(HttpContext.Request.GetDisplayUrl(), response);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale(Guid id) {
        await _mediator.Send(new DeleteSaleCommand(id));
        return Ok(new { Message = "A Venda foi removida com sucesso." });
    }

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleDto dto)
{
    dto.IdSale = id;

    try
    {
        await _mediator.Send(new UpdateSaleCommand(id, dto));
        return Ok(new { Message = "A Venda foi atualizada com sucesso." });
    }
    catch (Exception ex)
    {
        return NotFound(new { Message = ex.Message });
    }
}

    [HttpGet("report")]
        public async Task<IActionResult> GetSalesReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            var result = await _mediator.Send(new GetSalesReportQuery
            {
                StartDate = startDate,
                EndDate = endDate
            });
        return Ok(result);
    }

}