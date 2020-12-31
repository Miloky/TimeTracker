using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence.Configurations
{
    public class WorkLogConfiguration : IEntityTypeConfiguration<WorkLog>
    {
        public void Configure(EntityTypeBuilder<WorkLog> builder)
        {
            builder.ToTable("WorkLogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.IssueId).IsRequired();


            builder.HasOne(x => x.Issue).WithMany(x => x.WorkLogs);
        }
    }
}
