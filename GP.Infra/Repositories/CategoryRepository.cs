using GP.Domain.Entities;
using GP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Infra.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(DBGeniusContext geniusContext) : base(geniusContext)
		{
		}
	}
}
