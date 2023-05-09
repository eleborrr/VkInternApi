using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext() : base()
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VkInternDB;Username=postgres;Password=18ZIfigi_");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups {get; set; }
    public DbSet<UserState> UserStates { get; set; }
}