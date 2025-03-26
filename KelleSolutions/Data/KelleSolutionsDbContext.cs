using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KelleSolutions.Models;
using System.Linq;

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
            /*if (!builder.Model.GetEntityTypes().Any(t => t.ClrType == typeof(IdentityRole)))
            {
                var admin = new IdentityRole("Admin") { NormalizedName = "ADMIN" };
                var broker = new IdentityRole("Broker") { NormalizedName = "BROKER" };
                var agent = new IdentityRole("Agent") { NormalizedName = "AGENT" };

                builder.Entity<IdentityRole>().HasData(admin, broker, agent);
            }*/

            // One Tenant can have Many Users
            builder.Entity<User>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TenantID)
                .OnDelete(DeleteBehavior.Restrict); // Prevents accidental deletions

            builder.Entity<Tenant>().ToTable("Tenant");

            // Configure TenantToPerson
            builder.Entity<TenantToPerson>()
                .HasKey(tp => new { tp.TenantID, tp.PersonID });

            builder.Entity<TenantToPerson>()
                .HasOne(tp => tp.Tenant)
                .WithMany(t => t.TenantToPeople)
                .HasForeignKey(tp => tp.TenantID)
                .HasConstraintName("FK_TenantToPeople_Tenant_TenantID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TenantToPerson>()
                .HasOne(tp => tp.Person)
                .WithMany()
                .HasForeignKey(tp => tp.PersonID)
                .HasConstraintName("FK_TenantToPeople_AspNetUsers_PersonID")
                .OnDelete(DeleteBehavior.Restrict); // Prevents accidental deletions

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Broker", NormalizedName = "BROKER" },
                new IdentityRole { Name = "Agent", NormalizedName = "AGENT" });

            // Relationship between Listing and Property
            // Updated: Using the navigation property 'PropertyDetails' (of type Property)
            // and the foreign key property 'Property' (an int) as defined in the Listing model.
            builder.Entity<Listing>()
    .HasOne(l => l.PropertyDetails)
    .WithMany()  // No navigation property on Property
    .HasForeignKey(l => l.FK_Property)  // Updated to use the new property name
    .OnDelete(DeleteBehavior.Cascade);



            // Configure PersonToEntity
            builder.Entity<PersonToEntity>()
                .HasOne(pe => pe.PersonNavigation)
                .WithMany()
                .HasForeignKey(pe => pe.Person)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToEntity>()
                .HasOne(pe => pe.EntityNavigation)
                .WithMany()
                .HasForeignKey(pe => pe.Entity)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure PersonToPerson
            builder.Entity<PersonToPerson>()
                .HasOne(p => p.Person)
                .WithMany()
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToPerson>()
                .HasOne(p => p.Person2)
                .WithMany()
                .HasForeignKey(p => p.Person2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure PersonToProperties
            builder.Entity<PersonToProperties>()
                .HasOne(p => p.People)
                .WithMany()
                .HasForeignKey(p => p.Person)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToProperties>()
                .HasOne(p => p.Property)
                .WithMany()
                .HasForeignKey(p => p.Properties)
                .OnDelete(DeleteBehavior.Restrict);

            //Configure PersonToAffiliation
            builder.Entity<PersonToAffiliations>()
                .HasOne(p => p.PersonNavigation)
                .WithMany()
                .HasForeignKey(p => p.Person)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToAffiliations>()
                .HasOne(p => p.AffiliationNavigation)
                .WithMany()
                .HasForeignKey(p => p.Affiliate)
                .OnDelete(DeleteBehavior.Restrict);

            //Configure PersonToLeads
            builder.Entity<PersonToLeads>()
                .HasOne(p => p.PersonNavigation)
                .WithMany()
                .HasForeignKey(p => p.Person)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToLeads>()
                .HasOne(p => p.LeadNavigation)
                .WithMany()
                .HasForeignKey(p => p.Lead)
                .OnDelete(DeleteBehavior.Restrict);


            // Configure PermissionGroup
            builder.Entity<PermissionGroup>()
                .HasKey(pg => pg.PermissionGroupID);

            // Define the parent-child relationship within PermissionGroups
            builder.Entity<PermissionGroup>()
                .HasMany(pg => pg.ChildGroups)
                .WithOne(pg => pg.ParentGroup)
                .HasForeignKey(pg => pg.ParentGroupID)
                .OnDelete(DeleteBehavior.Restrict);

            // Set up the relationship between PermissionGroup and Permissions
            builder.Entity<PermissionGroup>()
                .HasOne(pg => pg.Permission)
                .WithMany()
                .HasForeignKey(pg => pg.PermissionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionGroup>()
                .Property(pg => pg.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<PermissionGroup>()
                .Property(pg => pg.Updated)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<RolePermissionGroupEntity>()
                .HasKey(rpge => new { rpge.RoleID, rpge.PermissionGroupID, rpge.PageAccessID });

            builder.Entity<RolePermissionGroupEntity>()
                .HasOne(rpge => rpge.RoleNavigation)
                .WithMany()
                .HasForeignKey(rpge => rpge.RoleID);

            builder.Entity<RolePermissionGroupEntity>()
                .HasOne(rpge => rpge.PermissionGroupNavigation)
                .WithMany()
                .HasForeignKey(rpge => rpge.PermissionGroupID);

            builder.Entity<RolePermissionGroupEntity>()
                .HasOne(rpge => rpge.PageAccess)
                .WithMany()
                .HasForeignKey(rpge => rpge.PageAccessID);

            // Configure PersonToListing
            builder.Entity<PersonToListing>()
                .HasOne(ptl => ptl.Person)
                .WithMany() // No navigation property on Person
                .HasForeignKey(ptl => ptl.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PersonToListing>()
                .HasOne(ptl => ptl.Listing)
                .WithMany() // No navigation property on Listing
                .HasForeignKey(ptl => ptl.ListingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Dashboard
            builder.Entity<Dashboard>()
                .HasOne(d => d.User)
                .WithOne(u => u.Dashboard)
                .HasForeignKey<Dashboard>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade); // If a user is deleted, their dashboard is deleted too
        }

        // DbSet for Tenants
        public DbSet<Tenant> Tenants { get; set; }

        // DbSet for TenantToPerson
        public DbSet<TenantToPerson> TenantToPeople { get; set; }   

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

        // DbSet for Permissions
        public DbSet<Permission> Permissions { get; set; }

        // DbSet for PermissionGroup
        public DbSet<PermissionGroup> PermissionGroups { get; set; }

        // DbSet for PersonToEntity
        public DbSet<PersonToEntity> PersonToEntity { get; set; }

        // DbSet for RolePermissionGroupEntity
        public DbSet<RolePermissionGroupEntity> RolePermissionGroupEntity { get; set; }

        //DbSet for PersonToPerson
        public DbSet<PersonToPerson> PersonToPerson {get;set;}

        //DbSet for PersonToProperties
        public DbSet<PersonToProperties> PersonToProperties {get;set;}

        //DbSet for PersonToEntities
        public DbSet<PersonToAffiliations> PersonToAffiliations {get;set;}

        //DbSet for PersonToLeads
        public DbSet<PersonToLeads> PersonToLeads {get;set;}

        //DbSet for Actions
        public DbSet<ActionEntity> ActionEntities { get; set; }

        public DbSet<Dashboard> Dashboards { get; set; }

        //DbSet for StatusMappings
        public DbSet<StatusMapping> StatusMappings { get; set; }

        //DbSet for SellerIDMappings
        public DbSet<SellerIDMapping> SellerIDMappings { get; set; }
    }
}
