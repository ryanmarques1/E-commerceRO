using MediatR;
using RO.DevTest.Domain.Exception;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Product.IdProd);
        if (product == null)
            throw new Exception("Produto não encontrado");

        product.nameProd = request.Product.nameProd;
        product.descriptionProd = request.Product.descriptionProd;
        product.priceProd = request.Product.priceProd;
        product.quantityStock = request.Product.quantityStock;
        
        await _productRepository.UpdateAsync(product);

        Console.WriteLine($"Produto com ID{product.IdProd} foi atualizado com sucesso.");
        return Unit.Value;
    }
}