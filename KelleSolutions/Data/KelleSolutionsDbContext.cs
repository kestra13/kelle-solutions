using Microsoft.AspNetCore.Identity;
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

            builder.Entity<Property>()
                .HasOne(p => p.Tenant)
                .WithMany()
                .HasForeignKey(p => p.TenantID)
                .HasConstraintName("FK_Properties_Tenant_TenantID") 
            .OnDelete(DeleteBehavior.Cascade);

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

            builder.Entity<PermissionGroup>()
                .HasKey(pg => pg.PermissionGroupID);

            builder.Entity<PermissionGroup>()
                .HasOne(pg => pg.ParentGroup)
                .WithMany()
                .HasForeignKey(pg => pg.ParentGroupID);

            builder.Entity<PermissionGroup>()
                .HasOne(pg => pg.Permission)
                .WithMany()
                .HasForeignKey(pg => pg.PermissionID);

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

        // DbSet for PersonToEntity
        public DbSet<PersonToEntity> PersonToEntity { get; set; }

        // DbSet for PermissionGroup
        public DbSet<PermissionGroup> PermissionGroup { get; set; }
        
        // DbSet for RolePermissionGroupEntity
        public DbSet<RolePermissionGroupEntity> RolePermissionGroupEntity { get; set; }

        // DbSet for Permissions
        public DbSet<Permission> Permissions { get; set; }

    }
}
