using MediatR;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.Application.Features.Sale.Commands.CreateSaleCommand;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string IdUser { get; set; } = null!;
    public List<CreateItemSaleDto> Items { get; set; } = new();
}

public class CreateItemSaleDto
{
    public Guid ProductId { get; set; }
    public int QuantitySale { get; set; }
}
