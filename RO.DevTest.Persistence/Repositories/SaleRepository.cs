using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

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
}
