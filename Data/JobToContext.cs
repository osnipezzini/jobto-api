using JobTo.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTo.API.Data
{
    public class JobToContext : DbContext
    {
        public JobToContext(DbContextOptions<JobToContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("GridSeq");

            modelBuilder.Entity<Person>().Property("Grid").HasDefaultValueSql("nextval('\"GridSeq\"')");
            modelBuilder.Entity<Person>().Property("Type").HasDefaultValue("C");
        }
    }
}
