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
            modelBuilder.HasSequence<long>("grid_seq");
            modelBuilder.HasSequence<int>("person_cod_seq");

            modelBuilder.Entity<Person>().Property("Grid").HasDefaultValueSql("nextval('grid_seq')");
            modelBuilder.Entity<Person>().Property("Code").HasDefaultValueSql("nextval('person_cod_seq')");
            modelBuilder.Entity<Person>().Property("Type").HasDefaultValue("C");
            modelBuilder.Entity<Person>().Property("Active").HasDefaultValue(true);
            modelBuilder.Entity<Person>().Property("CreatedAt").HasDefaultValueSql("now()");
            modelBuilder.Entity<Person>().Property("UpdatedAt").HasDefaultValueSql("now()");
            
            modelBuilder.Entity<User>().Property("Role").HasDefaultValue("User");
        }
    }
}
