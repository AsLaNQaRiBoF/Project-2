using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication3.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }

    }
}
