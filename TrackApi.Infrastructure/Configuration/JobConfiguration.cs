using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Title).IsRequired().HasMaxLength(1500);
            builder.Property(j => j.ParentJobId).IsRequired(false);
            builder.Ignore(j => j.Status);
            builder.Property(j => j.StartDate).IsRequired();
            builder.Property(j => j.EndDate).IsRequired();
            builder.Property(j => j.Description).IsRequired(false).HasMaxLength(2500);
            builder.Property(j => j.Prioritylevel).IsRequired();
            builder.HasOne<Job>().WithMany().HasForeignKey(j => j.ParentJobId);
            builder.HasOne<Goal>().WithMany().HasForeignKey(j => j.GoalId);
        }
    }
}
