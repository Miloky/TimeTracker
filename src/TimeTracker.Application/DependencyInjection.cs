using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Application.Projects.Queries.GetProjectList;

namespace TimeTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetProjectListQuery).Assembly);
            return services;
        }
    }
}