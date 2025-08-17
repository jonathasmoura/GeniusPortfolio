using GP.Domain.Entities.DomainBase;
using GP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Infra.Repositories
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
	{
		protected readonly DBGeniusContext _geniusContext;

		protected GenericRepository(DBGeniusContext geniusContext)
		{
			_geniusContext = geniusContext;
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _geniusContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(Guid id)
		{
			return await _geniusContext.Set<T>().FindAsync(id);
		}

		public async Task Add(T entity)
		{
			await _geniusContext.Set<T>().AddAsync(entity);
		}
		public void Update(T entity)
		{
			_geniusContext.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			_geniusContext.Set<T>().Remove(entity);
		}
	}
}
