using VkInternApi.Data.Repositories.UserGroupRep;
using VkInternApi.Data.Repositories.UserRep;
using VkInternApi.Data.Repositories.UserStateRep;

namespace VkInternApi.Data.Repositories;

public class RepositoryManager: IRepositoryManager
{
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IUserStateRepository> _lazyUserStateRepository;
    private readonly Lazy<IUserGroupRepository> _lazyUserGroupRepository;

    public RepositoryManager(ApplicationDbContext dbContext)
    {
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyUserStateRepository = new Lazy<IUserStateRepository>(() => new UserStateRepository(dbContext));
        _lazyUserGroupRepository = new Lazy<IUserGroupRepository>(() => new UserGroupRepository(dbContext));
    }

    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUserGroupRepository UserGroupRepository => _lazyUserGroupRepository.Value;
    public IUserStateRepository UserStateRepository => _lazyUserStateRepository.Value;

}