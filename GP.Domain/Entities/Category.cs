using GP.Domain.Entities.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Entities
{
	public class Category : EntityBase
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

	
	}
}
