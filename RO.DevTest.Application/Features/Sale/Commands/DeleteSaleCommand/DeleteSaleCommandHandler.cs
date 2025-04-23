using MediatR;

using RO.DevTest.Application.Contracts.Persistance.Repositories;
namespace RO.DevTest.Application.Features.Sale.Commands.DeleteSaleCommand;

public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, Unit>
{
    private readonly ISaleRepository _saleRepository;

    public DeleteSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<Unit> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var product = await _saleRepository.GetByIdAsync(request.Idsale);
        if (product == null)
            throw new Exception("Venda não encontrada.");

        await _saleRepository.DeleteAsync(product);
        Console.WriteLine($"Venda com ID {product.IdSale} foi removida com sucesso.");
        return Unit.Value;
    }
}