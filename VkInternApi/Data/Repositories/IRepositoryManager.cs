using VkInternApi.Data.Repositories.UserGroupRep;
using VkInternApi.Data.Repositories.UserStateRep;

namespace VkInternApi.Data.Repositories;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }
        
    IUserGroupRepository UserGroupRepository { get; }

    IUserStateRepository UserStateRepository { get; }
}