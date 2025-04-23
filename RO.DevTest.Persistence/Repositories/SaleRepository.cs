using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.Features.Sale.Queries;
using RO.DevTest.Application.DTOs;
namespace RO.DevTest.Persistence.Repositories;

public class SaleRepository(DefaultContext context) : ISaleRepository {
    private readonly DefaultContext _context = context;

    public async Task<Sale?> GetByIdAsync(Guid id) =>
        await _context.Sales.FindAsync(id);

    public async Task<IEnumerable<Sale>> GetAllAsync() =>
        await _context.Sales.ToListAsync();

    public async Task AddAsync(Sale sale) {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sale sale) {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sale sale) {
        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();
    }
    public async Task<SalesReportResult> GetSalesReportAsync(DateTime startDate, DateTime endDate)
{
    var sales = await _context.Sales
        .Include(s => s.Items)
        .ThenInclude(i => i.Product)
        .Where(s => s.DateSale >= startDate && s.DateSale <= endDate)
        .ToListAsync();

    var totalVendas = sales.Count;

    var rendaTotal = sales
        .SelectMany(s => s.Items)
        .Sum(i => i.quantitySale * i.Product.priceProd);

    var rendaPorProduto = sales
        .SelectMany(s => s.Items)
        .GroupBy(i => new { i.ProductId, i.Product.nameProd })
        .Select(g => new ProductRevenue
        {
            ProductId = g.Key.ProductId,
            ProductName = g.Key.nameProd,
            TotalRevenue = g.Sum(i => i.quantitySale * i.Product.priceProd),
            TotalQuantity = g.Sum(i => i.quantitySale)
        })
        .ToList();

    return new SalesReportResult
    {
        TotalSalesCount = totalVendas,
        TotalRevenue = rendaTotal,
        ProductRevenues = rendaPorProduto
    };
}

}
