using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;

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

        public DbSet<GpsPoint> gpsPoints { get; set; }
    }
}
