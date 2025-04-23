namespace RO.DevTest.Application.DTOs;

public class SalesReportResult
{
    public int TotalSalesCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<ProductRevenue> ProductRevenues { get; set; } = new();
}