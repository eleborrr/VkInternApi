using Microsoft.AspNetCore.Http.HttpResults;
using VkInternApi.Data.Dto;
using VkInternApi.Data.Repositories;

namespace VkInternApi.Services.User;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Entities.User> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<IEnumerable<Entities.User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<bool> AddUser(AddUserDto dto)
    {
        var user = new Entities.User
        {
            CreatedDate = dto.CreatedDate,
            Password = dto.Password,
            Login = dto.Login,
            UserStateId = dto.UserStateId,
            UserGroupId = dto.UserGroupId
        };
        await _userRepository.AddAsync(user);
        return true;
    }

    public async Task<bool> DeleteUser(DeleteUserDto dto)
    {
        var user = await _userRepository.GetUserById(dto.Id);
        if (user is null)
            return false;
        await _userRepository.RemoveAsync(user);
        return true;
    }
}