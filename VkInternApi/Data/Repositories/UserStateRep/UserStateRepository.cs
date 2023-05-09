using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserStateRep;

public class UserStateRepository: IUserStateRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserStateRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<UserState?> GetUserStateById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserState>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserState userState)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(UserState userState)
    {
        throw new NotImplementedException();
    }
}