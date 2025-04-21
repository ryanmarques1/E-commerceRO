namespace RO.DevTest.Application.DTOs;

public class CreateSaleDto{
    public Guid IdSale {get;set;}

    public string IdUser {get;set;} = null!;

    public DateTime DateSale {get;set;}

    public List<CreateItemSaleDto> Items {get;set;} = new();
}