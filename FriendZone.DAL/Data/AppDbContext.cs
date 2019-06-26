using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.DAL.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.Migrate();
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
            builder.Entity<UserProfile>()
                .Property(up => up.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<UserProfile>().
                Property(u => u.Birthday).HasColumnType("date");


            builder.Entity<Category>()
                .Property(c => c.Name).IsRequired();

            builder.Entity<Event>()
                .Property(e => e.OwnerUserId).IsRequired();
            builder.Entity<Event>()
                .HasOne(e => e.Owner)
                .WithMany(up => up.MyEvents);
            builder.Entity<Event>().
                Property(u => u.DateFrom).HasColumnType("date");
            builder.Entity<Event>().
                Property(u => u.DateTo).HasColumnType("date");

            builder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "FieldTrip"},
                new Category { Id = 2, Name = "Fishing"},
                new Category { Id = 3, Name = "Relaxing" },
                new Category { Id = 4, Name = "Board Games" },
                new Category { Id = 5, Name = "PC Games" },
                new Category { Id = 6, Name = "Mountains" }
            );

            builder.Entity<Country>()
                .Property(c => c.Name).IsRequired();
            builder.Entity<Country>()
                .HasIndex(c => c.Name).IsUnique();
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Ukraine" }
            );

            builder.Entity<City>()
                .Property(c => c.Name).IsRequired();
            builder.Entity<City>().HasData(
                new City { Id = 1, CountryId = 1, Name = "Kyiv" },
                new City { Id = 2, CountryId = 1, Name = "Khotyn" },
                new City { Id = 3, CountryId = 1, Name = "Vijnitsya" },
                new City { Id = 4, CountryId = 1, Name = "Chernivtsi" }
            );
        }
    }

    


    
}
