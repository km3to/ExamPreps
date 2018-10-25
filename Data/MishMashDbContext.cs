using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data
{
    public class MishMashDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=MishMashDb;Integrated Security=True;")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Channels)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            builder
                .Entity<Channel>()
                .HasMany(c => c.Users)
                .WithOne(uc => uc.Channel)
                .HasForeignKey(uc => uc.ChannelId);

            builder
                .Entity<Channel>()
                .HasMany(c => c.Tags)
                .WithOne(ct => ct.Channel)
                .HasForeignKey(ct => ct.ChannelId);

            builder
                .Entity<Tag>()
                .HasMany(t => t.Channels)
                .WithOne(ct => ct.Tag)
                .HasForeignKey(ct => ct.TagId);
        }
    }
}