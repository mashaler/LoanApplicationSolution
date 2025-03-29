using Microsoft.EntityFrameworkCore;
using LoanApplicationApi.Models;

namespace LoanApplicationApi.Data
{
    public class LoanApplicationContext : DbContext
    {
        public LoanApplicationContext(DbContextOptions<LoanApplicationContext> options)
            : base(options) { }

        public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}
