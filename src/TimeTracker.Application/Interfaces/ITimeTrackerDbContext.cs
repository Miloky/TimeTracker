using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Interfaces
{
    public interface ITimeTrackerDbContext
    {
        DbSet<Issue> Issues { get; set; }
        DbSet<Project> Projects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}