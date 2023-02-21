using Meteorites.Models;
using Microsoft.EntityFrameworkCore;

namespace Meteorites.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<MeteoriteViewModel> Meteorites { get; set; }
        public DbSet<GeoDB> GeoDB { get; set; }
    }
}
