using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserById(int id);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task AddAsync(User user);
    public Task RemoveAsync(User user);
}