using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser> 
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
            : base(options) { }
    }
}