using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserGroupRep;

public interface IUserGroupRepository
{
    public Task<UserGroup?> GetUserGroupById(int id);
    public Task<IEnumerable<UserGroup>> GetAllAsync();
    public Task AddAsync(UserGroup userGroup);
    // public Task RemoveAsync(UserGroup userGroup);
}