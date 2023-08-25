namespace Presentation.Application.Repository.Interface
{
    public interface ISqlRepository<TEntity> where TEntity : class
    {
        void AddEntitylog(TEntity entity);

    }
}
