using VkInternApi.Data.Dto;
using VkInternApi.Data.Repositories;

namespace VkInternApi.Services.User;

public class UserService: IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<ShowUserDto> GetUserById(int id)
    {
        var user = await _repositoryManager.UserRepository.GetUserById(id);
        var user_group = await _repositoryManager.UserGroupRepository.GetUserGroupById(user.UserGroupId);
        var user_state = await _repositoryManager.UserStateRepository.GetUserStateById(user.UserStateId);
        var dto = new ShowUserDto()
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            CreatedDate = user.CreatedDate,
            UserGroupId = user.UserGroupId,
            UserStateId = user.UserStateId,
            GroupCode = user_group.Code,
            GroupDescription = user_group.Description,
            StateCode = user_state.Code,
            StateDescription = user_state.Description
        };
        return dto;
    }

    public async Task<IEnumerable<ShowUserDto>> GetAllAsync()
    {
        var users = await _repositoryManager.UserRepository.GetAllAsync();
        var result = new List<ShowUserDto>();
        foreach (var user in users)
        {
            var user_group = await _repositoryManager.UserGroupRepository.GetUserGroupById(user.UserGroupId);
            var user_state = await _repositoryManager.UserStateRepository.GetUserStateById(user.UserStateId);
            result.Add(new ShowUserDto
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                CreatedDate = user.CreatedDate,
                UserGroupId = user.UserGroupId,
                UserStateId = user.UserStateId,
                GroupCode = user_group.Code,
                GroupDescription = user_group.Description,
                StateCode = user_state.Code,
                StateDescription = user_state.Description
            });
        }

        return result;
    }

    public async Task<UserChangeResponseDto> AddUser(AddUserDto dto)
    {
        var user = new Entities.User
        {
            CreatedDate = dto.CreatedDate,
            Password = dto.Password,
            Login = dto.Login,
            UserStateId = dto.UserStateId,
            UserGroupId = dto.UserGroupId
        };

        var adminGroup = (await _repositoryManager.UserGroupRepository.GetAllAsync())
            .FirstOrDefault(s => s.Code == "Admin");

        var usersGroup = await _repositoryManager.UserGroupRepository.GetUserGroupById(user.UserGroupId);

        if (usersGroup is not null && usersGroup.Code == "Admin" && adminGroup is not null &&
            adminGroup.Code == "Admin")
            return new UserChangeResponseDto(){IsSuccessful = false, Message = "Can't create another Admin"};
        
        
        await _repositoryManager.UserRepository.AddAsync(user);
        return new UserChangeResponseDto(){IsSuccessful = true, Message = "Successful user adding"};
    }

    public async Task<UserChangeResponseDto> DeleteUser(DeleteUserDto dto)
    {
        var user = await _repositoryManager.UserRepository.GetUserById(dto.Id);
        if (user is null)
            return new UserChangeResponseDto(){IsSuccessful = false, Message = "Can't find user by this id"};
        await _repositoryManager.UserRepository.RemoveAsync(user);
        return new UserChangeResponseDto(){IsSuccessful = true, Message = "User has been successfully deleted"};
    }
}