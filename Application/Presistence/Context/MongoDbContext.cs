using ParkBee.MongoDb;

namespace Application.Presistence.Context
{
    public class MongoDbContext : MongoContext
    {
        public MongoDbContext(IMongoContextOptionsBuilder optionsBuilder) : base(optionsBuilder)
        {

        }

    }
}
