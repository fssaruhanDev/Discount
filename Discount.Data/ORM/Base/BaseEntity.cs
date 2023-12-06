using System;
using System.ComponentModel.DataAnnotations;

namespace Discount.Data.ORM.Base
{
	public abstract class BaseEntity
	{
		[Key]
		public int ID { get; set; }

		public DateTime? UpdateDate { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }



	}
}

