using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext() : base()
    {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups {get; set; }
    public DbSet<UserState> UserStates { get; set; }
}