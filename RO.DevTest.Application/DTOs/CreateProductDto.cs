
namespace RO.DevTest.Application.DTOs;

public class CreateProductDto{
    public string nameProd {get;set;} = string.Empty;
    public string descriptionProd {get;set;} = string.Empty;
    public int quantityStock {get;set;}
    public decimal Price {get;set;}

    public static implicit operator CreateProductDto(ProductDto v)
    {
        throw new NotImplementedException();
    }
}