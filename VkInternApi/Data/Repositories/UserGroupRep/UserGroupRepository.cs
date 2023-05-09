using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserGroupRep;

public class UserGroupRepository: IUserGroupRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserGroupRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserGroup?> GetUserGroupById(int id)
    {
        return _dbContext.UserGroups.FirstOrDefault(g => g.Id == id);
    }

    public async Task<IEnumerable<UserGroup>> GetAllAsync()
    {
        return await _dbContext.UserGroups.ToListAsync();
    }

    public async Task AddAsync(UserGroup userGroup)
    {
        _dbContext.UserGroups.Add(userGroup);
        await _dbContext.SaveChangesAsync();
        
    }
}