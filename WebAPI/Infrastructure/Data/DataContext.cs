using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Follow> Followings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<User>()
                .HasMany(x => x.Follows)
                .WithOne()
                .HasForeignKey(x => x.FollowId);
        }
    }
}
