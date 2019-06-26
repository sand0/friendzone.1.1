﻿// <auto-generated />
using System;
using Friendzone.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Friendzone.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190626162303_addEventProfileRelationship-3")]
    partial class addEventProfileRelationship3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "FieldTrip" },
                        new { Id = 2, Name = "Fishing" },
                        new { Id = 3, Name = "Relaxing" },
                        new { Id = 4, Name = "Board Games" },
                        new { Id = 5, Name = "PC Games" },
                        new { Id = 6, Name = "Mountains" }
                    );
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, CountryId = 1, Name = "Kyiv" },
                        new { Id = 2, CountryId = 1, Name = "Khotyn" },
                        new { Id = 3, CountryId = 1, Name = "Vijnitsya" },
                        new { Id = 4, CountryId = 1, Name = "Chernivtsi" }
                    );
                });

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new { Id = 1, Name = "Ukraine" }
                    );
                });

            modelBuilder.Entity("Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("Description");

                    b.Property<string>("OwnerUserId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Unname");

                    b.Property<int?>("PhotoId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Entities.EventCategory", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("CategoryId");

                    b.HasKey("EventId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("EventCategory");
                });

            modelBuilder.Entity("Entities.EventUserProfile", b =>
                {
                    b.Property<string>("UserProfileId");

                    b.Property<int>("EventId");

                    b.HasKey("UserProfileId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventUserProfile");
                });

            modelBuilder.Entity("Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("ProfileId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entities.UserProfile", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int?>("AvatarId");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<int?>("CityId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UserId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("CityId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Entities.UserProfileCategory", b =>
                {
                    b.Property<string>("UserProfileId");

                    b.Property<int>("CategoryId");

                    b.HasKey("UserProfileId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserProfileCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "68b46095-fff5-402e-8566-2cc678599cf2", ConcurrencyStamp = "27020beb-259c-4cd6-ae94-1117f3203928", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "f948dd72-6256-4bd5-b7d3-9f0c1979251a", ConcurrencyStamp = "36e4f573-0c8a-4ad6-b5a0-6e0ebfc83bc6", Name = "User", NormalizedName = "USER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.HasOne("Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Event", b =>
                {
                    b.HasOne("Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Entities.UserProfile", "Owner")
                        .WithMany("MyEvents")
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("Entities.EventCategory", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("EventCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Event", "Event")
                        .WithMany("EventCategory")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.EventUserProfile", b =>
                {
                    b.HasOne("Entities.Event", "Event")
                        .WithMany("Visitors")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.UserProfile", "UserProfile")
                        .WithMany("ChosenEvents")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.UserProfile", b =>
                {
                    b.HasOne("Entities.Photo", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.HasOne("Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.UserProfileCategory", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("UserProfileCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.UserProfile", "UserProfile")
                        .WithMany("UserProfileCategory")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
