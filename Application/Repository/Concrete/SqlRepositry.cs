using Application.Presistence.Context;
using Application.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.Concrete
{
    public class SqlRepositry<T> : ISqlRepository<T> where T : class
    {
        private readonly SqlDbContext _sqlcontext;
        private readonly DbSet<T> entities;
        readonly Dictionary<string,string> errorMesages =new();

        public SqlRepositry(SqlDbContext sqlcontext)
        {
           _sqlcontext = sqlcontext;
            entities = _sqlcontext.Set<T>();
        }

        public void AddEntitylog(T entity)
        {
          //  ArgumentNullException.ThrowIfNull((entity));
            try
            {
               
                entities.Add(entity);
                _sqlcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMesages.Add(entity.ToString(),ex.InnerException.ToString());
            }
            finally
            {
              //  _sqlcontext.Dispose();
            }
        }

    }
}
