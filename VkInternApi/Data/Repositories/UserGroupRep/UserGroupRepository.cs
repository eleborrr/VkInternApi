using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserGroupRep;

public class UserGroupRepository: IUserGroupRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserGroupRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<UserGroup?> GetUserGroupById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserGroup>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(UserGroup userGroup)
    {
        throw new NotImplementedException();
    }
}