namespace Application.Repository.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : class
    {
        Task InsertLogAsync(TDocument document);
    }
}
