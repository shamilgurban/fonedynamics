using Microsoft.EntityFrameworkCore;
using Shared.Data.Entities;

namespace Fonedynamics.Console.Data
{
    public class PhonedynamicsContext : DbContext
    {
        public PhonedynamicsContext()
        {
        }

        public DbSet<SMS> SMSes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=fonedynamicsdb;Database=PhonedynamicsDb;User Id=sa;Password=P@ssw0rd!;");
        }
    }
}
