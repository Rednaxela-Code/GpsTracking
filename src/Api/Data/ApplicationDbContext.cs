using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<GpsPoint> GpsPoints { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
