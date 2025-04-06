using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Configuration
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goals");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Title).IsRequired().HasMaxLength(1500);
            builder.Ignore(g => g.Status);
            builder.Property(g => g.TargetDate).IsRequired();
            builder.Property(g => g.Description).IsRequired(false).HasMaxLength(2500);
            builder.Property(g=> g.PlanId).IsRequired();
            builder.HasOne<Plan>().WithMany().HasForeignKey(g => g.PlanId);
        }
    }
}
