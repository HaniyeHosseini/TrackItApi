using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Configuration
{
    public class JobTagConfiguration : IEntityTypeConfiguration<JobTag>
    {
        public void Configure(EntityTypeBuilder<JobTag> builder)
        {
            builder.ToTable("JobTags");
            builder.HasKey(t => new { t.JobId, t.TagId });
            builder.HasOne<Job>().WithMany().HasForeignKey(t => t.JobId);
            builder.HasOne<Tag>().WithMany().HasForeignKey(t => t.TagId);
        }
    }
}
