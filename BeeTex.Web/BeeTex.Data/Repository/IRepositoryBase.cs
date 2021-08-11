using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BeeTex.Data.Repository
{
	public interface IRepositoryBase<T>
    {
        //Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression, int page = 1);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);

        Task<T> FindById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity); //(T entity);
    }
}
