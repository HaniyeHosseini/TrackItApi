using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Configuration
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("Plans");
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id).UseIdentityColumn();
            builder.Property(p => p.PlanType).HasColumnType("int").IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(g => g.Description).IsRequired(false).HasMaxLength(2500);
            builder.HasOne<Plan>().WithMany().HasForeignKey(j => j.ParentPlanId);

        }
    }
}
