using VkInternApi.Data.Dto;
using VkInternApi.Entities;

namespace VkInternApi.Services.User;

public interface IUserService
{
    public Task<ShowUserDto> GetUserById(int id);
    public Task<IEnumerable<ShowUserDto>> GetAllAsync(UserParameters userParameters);
    public Task<UserChangeResponseDto> AddUser(AddUserDto dto);
    public Task<UserChangeResponseDto> DeleteUser(DeleteUserDto dto);
}