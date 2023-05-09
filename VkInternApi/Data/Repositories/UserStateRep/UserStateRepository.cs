using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserStateRep;

public class UserStateRepository: IUserStateRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserStateRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserState?> GetUserStateById(int id)
    {
        return _dbContext.UserStates.FirstOrDefault(s => s.Id == id);
    }

    public async Task<IEnumerable<UserState>> GetAllAsync()
    {
        return await _dbContext.UserStates.ToListAsync();
    }

    public async Task AddAsync(UserState userState)
    {
        _dbContext.UserStates.Add(userState);
        await _dbContext.SaveChangesAsync();    }

    // public Task RemoveAsync(UserState userState)
    // {
    //     throw new NotImplementedException();
    // }
}