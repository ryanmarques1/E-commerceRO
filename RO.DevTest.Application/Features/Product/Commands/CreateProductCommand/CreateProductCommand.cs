using MediatR;


namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommand : IRequest<CreateProductResult> {
    public string nameProd {get;set;} = string.Empty;

    public string descriptionProd {get;set;} = string.Empty;

    public decimal priceProd {get;set;}

    public int quantityStock {get;set;}

    public Domain.Entities.Product AssignTo() {
        return new Domain.Entities.Product {
            nameProd = nameProd,
            descriptionProd = descriptionProd,
            priceProd = priceProd,
            quantityStock = quantityStock,
        };
    }
}
