using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {} 
        public DbSet<CreatedEvent> CreatedEvents { get; set; }
        public DbSet<Participation> Participations { get; set; }
    }
}