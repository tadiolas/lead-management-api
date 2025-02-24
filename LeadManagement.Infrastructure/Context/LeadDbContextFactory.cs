using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Context
{
    public class LeadDbContextFactory : IDesignTimeDbContextFactory<LeadDbContext>
    {
        public LeadDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeadDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=LeadAdmin;Password=SenhaForte123!;TrustServerCertificate=True;");

            return new LeadDbContext(optionsBuilder.Options);
        }
    }
}
