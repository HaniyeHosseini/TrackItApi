using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TrackItApi.Domain.Models;
using Job = TrackItApi.Domain.Models.Job;

namespace TrackApi.Infrastructure.Context
{
    public class TrackApiContext : DbContext
    {
        public TrackApiContext(DbContextOptions<TrackApiContext> otions) : base(otions)
        {
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JobTag> JobTags { get; set; }
        public DbSet<Goal> Goals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
