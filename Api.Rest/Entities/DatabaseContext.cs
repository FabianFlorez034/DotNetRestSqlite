using Microsoft.EntityFrameworkCore;

namespace Api.Rest.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
