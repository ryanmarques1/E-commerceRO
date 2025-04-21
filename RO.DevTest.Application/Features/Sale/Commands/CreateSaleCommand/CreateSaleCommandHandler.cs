using MediatR;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Sale.Commands.CreateSaleCommand;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public CreateSaleCommandHandler(
        ISaleRepository saleRepository,
        IUserRepository userRepository,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {   
        if (string.IsNullOrEmpty(request.IdUser)){
            throw new ArgumentNullException(nameof(request.IdUser), "ERRORR USER");
        }
        var user = await _userRepository.GetByIdAsync(Guid.Parse(request.IdUser));
        if (user == null)
            throw new Exception("Usuário não encontrado.");

       
        var sale = new RO.DevTest.Domain.Entities.Sale
        {
            IdUser = request.IdUser,
            DateSale = DateTime.UtcNow,
            Items = new List<ItemSale>()
        };

        foreach (var item in request.Items)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product == null)
                throw new Exception($"Produto {item.ProductId}não existe.");

            sale.Items.Add(new ItemSale
            {
                ProductId = item.ProductId,
                quantitySale = item.QuantitySale
            });
        }

        await _saleRepository.AddAsync(sale);

        return new CreateSaleResult
        {
            IdSale = sale.IdSale,
            DateSale = sale.DateSale
        };
    }
}
