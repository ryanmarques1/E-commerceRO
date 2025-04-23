using MediatR;
using RO.DevTest.Domain.Exception;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Sale.Commands.UpdateSaleCommand;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Unit>
{
    private readonly ISaleRepository _saleRepository;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Sale.IdSale);
        if (sale == null)
            throw new Exception("Venda não encontrada");

    sale.IdUser = request.Sale.ClientId;
    sale.DateSale = request.Sale.Date;

    
    sale.Items = request.Sale.Items.Select(itemDto => new ItemSale
    {
        Id = itemDto.Id,
        ProductId = itemDto.ProductId,
        quantitySale = itemDto.Quantity,
    }).ToList();
        
        await _saleRepository.UpdateAsync(sale);

        Console.WriteLine($"Venda com ID {sale.IdSale} foi atualizada com sucesso.");
        return Unit.Value;
    }
}