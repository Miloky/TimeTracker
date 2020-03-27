using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Persistence.Configurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Project).WithMany(x => x.Issues);
            builder.HasMany(x => x.WorkLogs).WithOne(x => x.Issue);
        }
    }
}
