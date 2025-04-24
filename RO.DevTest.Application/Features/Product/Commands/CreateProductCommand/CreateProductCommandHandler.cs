using System.Collections;
using MediatR;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Domain.Exception;


namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new RO.DevTest.Domain.Entities.Product
        {   
            IdProd = Guid.NewGuid(),
            nameProd = request.nameProd,
            descriptionProd = request.descriptionProd,
            priceProd = request.priceProd,
            quantityStock = request.quantityStock
        };
        if (string.IsNullOrWhiteSpace(request.nameProd))
            throw new BadRequestException("Nome do Produto é obrigatório.");


        await _repository.AddAsync(product);

        return new CreateProductResult(product);
    }
}
