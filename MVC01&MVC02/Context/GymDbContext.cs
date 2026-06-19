using Microsoft.EntityFrameworkCore;
using MVC01_MVC02.FluentConfigurations;
using MVC01_MVC02.Models;

namespace MVC01_MVC02.Context
{
    public class GymDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymG01Db;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());
        }
        

        public DbSet<Plan> Plans { get; set; }
    }
}
