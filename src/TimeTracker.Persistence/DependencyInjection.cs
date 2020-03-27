using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ITimeTrackerDbContext, TimeTrackerDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("TimeTracker")));
            return services;
        }
    }
}