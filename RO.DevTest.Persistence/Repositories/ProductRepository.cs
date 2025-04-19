using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories;

public class ProductRepository(DefaultContext context) : IProductRepository {
    private readonly DefaultContext _context = context;

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _context.Products.FindAsync(id);

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.ToListAsync();

    public async Task AddAsync(Product product) {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product) {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product) {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
