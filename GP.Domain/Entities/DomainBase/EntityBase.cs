using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Entities.DomainBase
{
	public class EntityBase
	{
		public EntityBase()
		{
			Id = Guid.NewGuid();
			IsActive = true;
			Created = DateTime.Now;
			ActivationDate = Created;
		}

		public Guid Id { get; set; }
		public bool IsActive { get; set; }
		public DateTime? ActivationDate { get; set; }
		public DateTime? InativationDate { get; set; }
		public DateTime Created { get; set; }

	}
}
