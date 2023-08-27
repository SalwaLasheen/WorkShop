namespace Secure.Application.Repository.Concrete
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : class
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
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
