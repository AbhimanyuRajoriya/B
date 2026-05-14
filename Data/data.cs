using Microsoft.EntityFrameworkCore;
using Bank.Model;

namespace Bank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<BankAccount> Accounts { get; set; }
    }
}