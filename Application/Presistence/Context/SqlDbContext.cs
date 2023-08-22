using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Presistence.Context
{
    public class SqlDbContext : DbContext
    {
       
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {

        }
        public virtual DbSet<ActionLogEntity> ActionLogEntity { get; set; }
        public virtual DbSet<SqlResponseEntity> ResponseEntity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
//EntityFrameworkCore\Add-Migration InitialSqlSchemaMigration -Context SqlDbContext -outputDir Presistence/Migrations