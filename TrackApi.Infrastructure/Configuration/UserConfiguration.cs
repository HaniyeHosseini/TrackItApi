using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(x => x.PasswordHash).HasColumnType("VARBINARY(512)").IsRequired();
            builder.Property(x => x.Role).IsRequired().HasColumnType("int");
        }
    }
}
