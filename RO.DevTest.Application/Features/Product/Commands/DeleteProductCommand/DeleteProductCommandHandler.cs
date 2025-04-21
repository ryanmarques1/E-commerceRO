using MediatR;

using RO.DevTest.Application.Contracts.Persistence.Repositories;
namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
            throw new Exception("Produto não encontrado");

        await _productRepository.DeleteAsync(product);
        Console.WriteLine($"Produto com ID {product.IdProd} foi removido com sucesso.");
        return Unit.Value;
    }
}