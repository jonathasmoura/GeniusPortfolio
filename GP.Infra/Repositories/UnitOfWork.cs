using GP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Infra.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DBGeniusContext _geniusContext;
		public ICategoryRepository Categories { get; }


		public UnitOfWork(DBGeniusContext geniusContext, ICategoryRepository categoryRepository)
		{
			_geniusContext = geniusContext;
			Categories = categoryRepository;
		}

		public int Save()
		{
			return _geniusContext.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_geniusContext.Dispose();
			}
		}

	}
}
