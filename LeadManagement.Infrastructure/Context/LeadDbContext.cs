using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LeadManagement.Infrastructure.Context
{
    public class LeadDbContext : DbContext
    {
        public LeadDbContext(DbContextOptions<LeadDbContext> options)
            : base(options)
        {
        }

        [Required]
        public DbSet<Lead> Lead { get; set; }

        [Required]
        public DbSet<Customer> Customer { get; set; }

        [Required]
        public DbSet<Category> Category { get; set; }

        [Required]
        public DbSet<AdditionalContact> AdditionalContact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lead>().ToTable("Lead");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<AdditionalContact>().ToTable("AdditionalContact");

        }
    }
}
