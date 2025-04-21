using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RO.DevTest.Persistence.Repositories;

public class UserRepository(DefaultContext context): BaseRepository<User>(context), IUserRepository { 
    private readonly DefaultContext _context = context;

    public async Task<User?> GetByIdAsync(Guid id) =>
        await _context.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _context.Users.ToListAsync();

    public async Task AddAsync(User user) {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user) {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user) {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
