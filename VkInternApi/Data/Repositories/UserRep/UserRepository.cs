using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserRep;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserById(int id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);
    public async Task<IEnumerable<User>> GetAllAsync() => await _dbContext.Users.ToListAsync();

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(User user)
    {
        // _dbContext.Entry(user).CurrentValues.SetValues();
        await _dbContext.SaveChangesAsync();
    }
}