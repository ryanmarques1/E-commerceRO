namespace RO.DevTest.Application.DTOs;

public class ProductRevenue
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal TotalRevenue { get; set; }
    public int TotalQuantity { get; set; }
}
