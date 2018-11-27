using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BerthaWebApplication.Models
{
    public class BerthaContext : DbContext
    {
        public BerthaContext(DbContextOptions<BerthaContext> options)
            : base(options)
        {

        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Health>()
            .Property(a => a.DateTime)
            .HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Environment>()
            .Property(b => b.DateTime)
            .HasDefaultValueSql("getdate()");
        }

    public DbSet<User> User { get; set; }
    public DbSet<Health> HealthRecord { get; set; }
    public DbSet<Environment> EnvironmentRecord { get; set; }
    }
}
