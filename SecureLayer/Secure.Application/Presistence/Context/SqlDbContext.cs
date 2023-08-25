namespace Secure.Presistence.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {

        }
        public virtual DbSet<OptionsList> OptionsLists { get; set; }
        public virtual DbSet<ResponseWsdl> ResponseWsdls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
//EntityFrameworkCore\Add-Migration InitialSqlSchemaMigration -Context SqlDbContext -outputDir Presistence/Migrations