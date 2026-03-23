using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Servicebookingsystem.infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); // Soft delete handled in DbContext
    }
}
