using VkInternApi.Data.Dto;

namespace VkInternApi.Services.User;

public interface IUserService
{
    public Task<ShowUserDto> GetUserById(int id);
    public Task<IEnumerable<ShowUserDto>> GetAllAsync();
    public Task<bool> AddUser(AddUserDto dto);
    public Task<bool> DeleteUser(DeleteUserDto dto);
}