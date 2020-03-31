using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;
using TimeTracker.Persistence.Configurations;

namespace TimeTracker.Persistence
{
    public class TimeTrackerDbContext : DbContext, ITimeTrackerDbContext
    {
        public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectConfiguration).Assembly);
        }
    }
}