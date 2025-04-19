using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistence.Repositories;

public interface IProductRepository {
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}