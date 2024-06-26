using AirlineCompany3.Repository.DatabaseContext;
using AirlineCompany3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AirlineCompany3.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ServerDatabaseContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ServerDatabaseContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includedProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (var property in includedProperties.Split(','))
                {
                    query = query.Include(property);
                }
            }
            var entities = query.ToList();
            return entities;
        }

        public T Get(Expression<Func<T, bool>> filter, string? includedProperties = null, bool orElseThrow = false)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (string property in includedProperties.Split(','))
                {
                    query = query.Include(property);
                }
            }
            T entity = query.First();

            if(entity == null && orElseThrow)
            {
                throw new KeyNotFoundException("Entity not found.");
            }

            return entity;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
