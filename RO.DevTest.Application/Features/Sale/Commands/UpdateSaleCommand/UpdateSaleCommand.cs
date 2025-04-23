using MediatR;
using RO.DevTest.Application.DTOs;

namespace RO.DevTest.Application.Features.Sale.Commands.UpdateSaleCommand;
public class UpdateSaleCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateSaleDto Sale { get; set; }

    public UpdateSaleCommand(Guid id, UpdateSaleDto sale)
    {
        Id = id;
        Sale = sale;
    }
}
