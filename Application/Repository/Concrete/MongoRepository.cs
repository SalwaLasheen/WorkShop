using Application.Presistence.Context;
using Application.Repository.Interface;
using Domain.Entity.Shared;
using MongoDB.Driver;

namespace Application.Repository.Concrete
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : class
    {
        private readonly MongoDbContext _mongoContext;

        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
            var database = _mongoContext.Database;
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));

        }
        public virtual Task InsertLogAsync(TDocument document)
        {
            ArgumentNullException.ThrowIfNull(document);
            return Task.Run(() => _collection.InsertOneAsync(document));
        }
        protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
    }
}
