namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public record CreateProductResult {
    public Guid IdProd {get;set;} = Guid.NewGuid();
    public string nameProd {get;set;} = string.Empty;

    public string descriptionProd {get;set;} = string.Empty;

    public decimal priceProd {get;set;}

    public int quantityStock {get;set;}

    public CreateProductResult () { }

    public CreateProductResult(Domain.Entities.Product Prod) { 
        IdProd = Prod.IdProd;
        nameProd = Prod.nameProd!;
        descriptionProd = Prod.descriptionProd!;
        priceProd = Prod.priceProd!;
        quantityStock = Prod.quantityStock!;
    }
}
