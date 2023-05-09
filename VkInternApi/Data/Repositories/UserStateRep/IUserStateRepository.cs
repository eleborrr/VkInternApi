using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserStateRep;

public interface IUserStateRepository
{
    public Task<UserState?> GetUserStateById(int id);
    public Task<IEnumerable<UserState>> GetAllAsync();
    public Task AddAsync(UserState userState);
    public Task RemoveAsync(UserState userState);
}