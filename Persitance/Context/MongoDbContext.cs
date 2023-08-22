using MongoDB.Driver;
namespace Presistence.Context
{
    public class MongoDbContext : MongoContext
    {
        // public IMongoContext _mongoContext { get; set; }

        public IMongoCollection<Resoi> DbSet { get; set; }
        public MongoDbContext(IMongoContextOptionsBuilder optionsBuilder) : base(optionsBuilder)
        {
            //_mongoContext = mongoContext;
        }
    }
}
