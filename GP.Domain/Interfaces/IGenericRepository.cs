using GP.Domain.Entities.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Interfaces
{
	public interface IGenericRepository<T> where T : EntityBase
	{
		Task<T> GetById(Guid id);
		Task<IEnumerable<T>> GetAll();
		Task Add(T entity);
		void Delete(T entity);
		void Update(T entity);
	}
}
