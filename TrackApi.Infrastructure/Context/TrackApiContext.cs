using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackItApi.Domain.Models;
using Job = TrackItApi.Domain.Models.Job;

namespace TrackApi.Infrastructure.Context
{
    public class TrackApiContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JobTag> JobTags { get; set; }
        public DbSet<Goal> Goals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
