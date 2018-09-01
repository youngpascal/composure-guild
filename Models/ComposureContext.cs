using Microsoft.EntityFrameworkCore;

namespace composure.Models
{
    public class ComposureContext : DbContext
    {
        public ComposureContext (DbContextOptions<ComposureContext> options)
            : base(options)
        {
        }

        public DbSet<composure.Models.NewApp> NewApp { get; set; }
    }
}