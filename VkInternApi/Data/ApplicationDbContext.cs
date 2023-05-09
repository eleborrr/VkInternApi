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
        modelBuilder.Entity<UserGroup>();
        modelBuilder.Entity<UserState>();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups {get; set; }
    public DbSet<UserState> UserStates { get; set; }
}