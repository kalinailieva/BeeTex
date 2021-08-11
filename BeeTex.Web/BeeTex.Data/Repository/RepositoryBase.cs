
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BeeTex.Data.Repository
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private const int itemsPerPage = 10;

        protected IUnitOfWork unitOfWork { get; set; }
       
        public RepositoryBase(IUnitOfWork unitOfWork)

        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(T entity)
        {
            await this.unitOfWork.Context.Set<T>().AddAsync(entity);
            await this.unitOfWork.Context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression)
        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> expression, int page = 1)
        {
            //return await this.unitOfWork.Context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
            return await this.unitOfWork.Context.Set<T>().Where(expression).AsNoTracking()
                .Skip((page-1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await this.unitOfWork.Context.Set<T>().Where(expression).AsNoTracking()
                .ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
		{
            var entities = await unitOfWork.Context.Set<T>().Where(expression).ToListAsync();
			return entities;
		}

		public async Task<T> FindById(Guid id)
        {
            var entity = await unitOfWork.Context.Set<T>().FindAsync(id).ConfigureAwait(false);
            return entity;
        }

        public async Task Update(T entity)
        {
            this.unitOfWork.Context.Set<T>().Update(entity);
            await this.unitOfWork.Context.SaveChangesAsync();          
        }

		public virtual async Task Delete(T entity)
		{
			await this.unitOfWork.Context.SaveChangesAsync();
		}
		//public virtual async Task<T> Delete(T entity)
		//{
		//	var result = this.unitOfWork.Context.Set<T>().Remove(entity);
		//	this.unitOfWork.Context.SaveChangesAsync();
		//	Console.WriteLine("Succeed");



		//}
	}
}
