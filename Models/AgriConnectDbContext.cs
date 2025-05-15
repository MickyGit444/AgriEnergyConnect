using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AgriConnectDbContext : DbContext
{
    public AgriConnectDbContext(DbContextOptions options) : base(options) { }

        public DbSet <SystemUser>   SystemUser { get; set; }
   public  DbSet<Grower>    Growers { get; set; }
            public DbSet<HarvestItem>       HarvestIteams{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)// my code edited and its edited by AI
    {
        modelBuilder.Entity<SystemUser>().HasData(
             new SystemUser { Id = 1, username = "grower1", Password = "grow123", Role = "Grower" },

            new SystemUser { Id = 2, username = "employee1", Password = "emp123", Role = "Employee" }
        );
    }
}
