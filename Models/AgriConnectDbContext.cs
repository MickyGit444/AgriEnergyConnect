using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AgriConnectDbContext : DbContext
{
    public AgriConnectDbContext(DbContextOptions options) : base(options) { }

    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<Grower> Growers { get; set; }
    public DbSet<HarvestItem> HarvestItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SystemUser>().HasData(
            new SystemUser { Id = 1, Username = "grower1", Password = "grow123", Role = "Grower" },
            new SystemUser { Id = 2, Username = "employee1", Password = "emp123", Role = "Employee" }
        );
    }
}
