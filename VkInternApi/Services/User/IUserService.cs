using VkInternApi.Data.Dto;

namespace VkInternApi.Services.User;

public interface IUserService
{
    public Task<Entities.User> GetUserById(int id);
    public Task<IEnumerable<Entities.User>> GetAllAsync();
    public Task<bool> AddUser(AddUserDto dto);
    public Task<bool> DeleteUser(DeleteUserDto dto);
}