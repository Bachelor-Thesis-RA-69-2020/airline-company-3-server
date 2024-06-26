using System.Linq.Expressions;

namespace AirlineCompany3.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includedProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includedProperties = null, bool orElseThrow = false);
        void Create(T entity);
    }
}

