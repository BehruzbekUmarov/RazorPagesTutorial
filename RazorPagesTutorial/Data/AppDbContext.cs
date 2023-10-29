using Microsoft.EntityFrameworkCore;

namespace RazorPagesTutorial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
    }
}
