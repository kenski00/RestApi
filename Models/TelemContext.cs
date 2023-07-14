using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TelemContext : DbContext
    {
        public TelemContext (DbContextOptions<TelemContext> options)
            : base(options)
        {
        }

        public DbSet<TelemItem> TelemItems { get; set; }
    }
}
