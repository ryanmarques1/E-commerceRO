namespace RO.DevTest.Application.DTOs;

public class CreateItemSaleDto{
    public int IdItemSale { get; set; }

    public Guid ProductId { get; set; }

    public int QuantitySale { get; set; }
}