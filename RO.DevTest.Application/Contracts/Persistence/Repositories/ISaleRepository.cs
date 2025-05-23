using RO.DevTest.Application.DTOs;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories;

public interface ISaleRepository
{
    Task<Sale?> GetByIdAsync(Guid id);
    Task<IEnumerable<Sale>> GetAllAsync();
    Task AddAsync(Sale sale);
    Task UpdateAsync(Sale sale);
    Task DeleteAsync(Sale sale);
    Task<SalesReportResult> GetSalesReportAsync(DateTime startDate, DateTime endDate);
}
