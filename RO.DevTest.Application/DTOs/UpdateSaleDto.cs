namespace RO.DevTest.Application.DTOs;

public class UpdateSaleDto
{
    public Guid IdSale { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public List<ItemSaleDto> Items { get; set; } = null!;
}

public class ItemSaleDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
