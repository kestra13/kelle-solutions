﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Models;

namespace KelleSolutions.Data
{
    public class KelleSolutionsDbContext : IdentityDbContext<User>
    {
        public KelleSolutionsDbContext(DbContextOptions<KelleSolutionsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ensure roles exist before inserting them
            if (!builder.Model.GetEntityTypes().Any(t => t.ClrType == typeof(IdentityRole)))
            {
                var admin = new IdentityRole("Admin") { NormalizedName = "ADMIN" };
                var broker = new IdentityRole("Broker") { NormalizedName = "BROKER" };
                var agent = new IdentityRole("Agent") { NormalizedName = "AGENT" };

                builder.Entity<IdentityRole>().HasData(admin, broker, agent);
            }

            // One Tenant can have Many Users
            builder.Entity<User>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TenantID)
                .OnDelete(DeleteBehavior.Restrict); // Prevents accidental deletions

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Broker", NormalizedName = "BROKER" },
                new IdentityRole { Name = "Agent", NormalizedName = "AGENT" });

            // Keep cascade delete for PropertyID
            builder.Entity<Listing>()
                .HasOne(l => l.Property)
                .WithMany(p => p.Listings)
                .HasForeignKey(l => l.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);

            // Prevent cascade delete for UserID (fixes multiple cascade paths)
            builder.Entity<Listing>()
                .HasOne(l => l.Agent)
                .WithMany()
                .HasForeignKey(l => l.AgentID)
                .OnDelete(DeleteBehavior.NoAction);

            // Explicitly set decimal precision for Price
            builder.Entity<Listing>()
                .Property(l => l.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Listing>()
                .Property(l => l.Status)
                .HasColumnType("nvarchar(50)");

            builder.Entity<Listing>()
                .Property(l => l.Affiliation)
                .HasColumnType("nvarchar(50)");

            builder.Entity<Person>()
                .HasOne(p => p.TeamNavigation)
                .WithMany()
                .HasForeignKey(p => p.Team)
                // this prevents cascading deletes
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Team>()
                .HasData(
                    new Team { TeamId = 1, Affiliation = "Scrumbags"},
                    new Team { TeamId = 2, Affiliation = "KelleSolutions"}
                );

            builder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, Name = "Admin"},
                    new Category { CategoryId = 2, Name = "Broker"},
                    new Category { CategoryId = 3, Name = "Tenant"}
                );
        }

        // DbSet for Tenants
        public DbSet<Tenant> Tenants { get; set; }

        // DbSet for Properties
        public DbSet<Property> Properties { get; set; }

        // DbSet for Leads
        public DbSet<Lead> Leads { get; set; }

        // DbSet for Listings
        public DbSet<Listing> Listings { get; set; }

        // DbSet for Transactions
        public DbSet<Transaction> Transactions { get; set; }

        // DbSet for Affiliates
        public DbSet<Affiliate> Affiliates { get; set; }

        // DbSet for Entities
        public DbSet<Entity> Entities { get; set; }

        // DbSet for People
        public DbSet<Person> People { get; set; }

        // DbSet for Teams
        public DbSet<Team> Teams { get; set; }

        // DbSet for Categories
        public DbSet<Category> Categories { get; set; }

    }
}
