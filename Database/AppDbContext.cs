
using Microsoft.EntityFrameworkCore;
using Sophia_Ltd.Models;

namespace Sophia_Ltd.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.Email).IsUnique();  

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });


            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications");
                entity.HasKey(a => a.ApplicationId);

                entity.Property(a => a.SubmittedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relationship: Application -> Employee
                entity.HasOne(a => a.ByEmployee)
                      .WithMany(e => e.ReviewedApplications)
                      .HasForeignKey(a => a.EmployeeId)
                      .OnDelete(DeleteBehavior.SetNull);  // If employee is deleted, keep application, null out reviewer
            });
        }
    }
}