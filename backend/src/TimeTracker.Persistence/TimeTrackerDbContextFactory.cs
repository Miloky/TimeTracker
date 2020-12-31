using Microsoft.EntityFrameworkCore;
using TimeTracker.Persistence.Infrastructure;

namespace TimeTracker.Persistence
{
    public class TimeTrackerDbContextFactory : DesignTimeDbContextFactoryBase<TimeTrackerDbContext>
    {
        protected override TimeTrackerDbContext CreateNewInstance(DbContextOptions<TimeTrackerDbContext> options)
        {
            return new TimeTrackerDbContext(options);
        }
    }
}