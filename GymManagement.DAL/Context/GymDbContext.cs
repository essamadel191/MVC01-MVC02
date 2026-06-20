using Microsoft.EntityFrameworkCore;
using GymManagement.DAL.FluentConfigurations;
using GymManagement.DAL.Models;

namespace GymManagement.DAL.Context
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());
        }
        

        public DbSet<Plan> Plans { get; set; }
    }
}
