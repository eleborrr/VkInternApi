using Microsoft.EntityFrameworkCore;
using VkInternApi.Entities;

namespace VkInternApi.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VkInternDB;Username=postgres;Password=18ZIfigi_");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserGroup>()
            .HasData(
                new UserGroup
                {
                    Id = 1,
                    Code = "User",
                    Description = "Registered user with limited access"
                },
                new UserGroup
                {
                    Id = 2,
                    Code = "Admin",
                    Description = "Registered user with extended access to add and delete some information"
                });
        modelBuilder.Entity<UserState>().HasData(
            new UserState
            {
                Id = 1,
                Code = "Active",
                Description = "User can access website"
            },
            new UserState
            {
                Id = 2,
                Code = "Blocked",
                Description = "User has no longer any access"
            }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups {get; set; }
    public DbSet<UserState> UserStates { get; set; }
}