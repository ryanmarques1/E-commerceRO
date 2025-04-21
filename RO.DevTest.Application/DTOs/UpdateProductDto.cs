namespace RO.DevTest.Application.DTOs;

public class UpdateProductDto{
    public Guid IdProd {get;set;}

    public string nameProd {get;set;} = string.Empty;

    public string descriptionProd {get;set;} = string.Empty;

    public decimal priceProd {get;set;}

    public int quantityStock {get;set;}


}