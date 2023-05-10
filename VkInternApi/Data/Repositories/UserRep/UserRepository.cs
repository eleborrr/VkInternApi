using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data.Repositories.UserRep;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserById(int id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);
    
    public async Task<IEnumerable<User>> GetUsers(UserParameters userParameters) => await _dbContext.Users
        .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
        .Take(userParameters.PageSize)
        .ToListAsync();
    public async Task<IEnumerable<User>> GetAllAsync() => await _dbContext.Users
        .ToListAsync();

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        Thread.Sleep(5000);
    }

    public async Task RemoveAsync(User user)
    {
        var userInactive = new User
        {
            Id = user.Id,
            CreatedDate = user.CreatedDate,
            Login = user.Login,
            Password = user.Password,
            UserStateId = user.UserStateId,
            UserGroupId = user.UserGroupId,
            Active = false
        };
        _dbContext.Entry(user).CurrentValues.SetValues(userInactive);
        await _dbContext.SaveChangesAsync();
    }
}