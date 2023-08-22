using Microsoft.EntityFrameworkCore;

namespace Presistence.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {

        }
        public virtual DbSet<ActionLogEntity> ActionLogEntity { get; set; }
        public virtual DbSet<ResponseEntity> ResponseEntity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
