using FriendZone.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Location> Locations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole() { Name = "User", NormalizedName = "User".ToUpper() }
            );

            // UserProfile-Category many-to-many
            builder.Entity<UserProfileCategory>()
                .HasKey(t => new { t.UserProfileId, t.CategoryId });
            builder.Entity<UserProfileCategory>()
                .HasOne(uc => uc.UserProfile)
                .WithMany(u => u.UserProfileCategory)
                .HasForeignKey(uc => uc.UserProfileId);
            builder.Entity<UserProfileCategory>()
                .HasOne(uc => uc.Category)
                .WithMany(c => c.UserProfileCategory)
                .HasForeignKey(uc => uc.CategoryId);

            // Event-Category many-to-many
            builder.Entity<EventCategory>()
                .HasKey(t => new { t.EventId, t.CategoryId });
            builder.Entity<EventCategory>()
                .HasOne(ec => ec.Event)
                .WithMany(e => e.EventCategory)
                .HasForeignKey(ec => ec.EventId);
            builder.Entity<EventCategory>()
                .HasOne(ec => ec.Category)
                .WithMany(c => c.EventCategory)
                .HasForeignKey(uc => uc.CategoryId);

            builder.Entity<UserProfile>()
                .HasKey(up => up.UserId);
            builder.Entity<UserProfile>()
                .HasAlternateKey(up => up.Id);
            builder.Entity<UserProfile>().
                Property(u => u.Birthday).HasColumnType("date");

            builder.Entity<Category>()
                .Property(c => c.Name).IsRequired();

            builder.Entity<Event>()
                .Property(e => e.OwnerId).IsRequired();
            builder.Entity<Event>().
                Property(u => u.DateFrom).HasColumnType("date");
            builder.Entity<Event>().
                Property(u => u.DateTo).HasColumnType("date");

        }
    }

    


    
}
