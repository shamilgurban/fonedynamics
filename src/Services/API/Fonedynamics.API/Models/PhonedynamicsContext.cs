using Microsoft.EntityFrameworkCore;
using Shared.Data.Entities;

namespace Fonedynamics.API.Models
{
    public class PhonedynamicsContext : DbContext
    {
        public PhonedynamicsContext(DbContextOptions<PhonedynamicsContext> options) : base(options)
        {
        }

        public DbSet<SMS> SMSes { get; set; }
    }
}
