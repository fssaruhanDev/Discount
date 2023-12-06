using System;
using Discount.Data.ORM.Base;

namespace Discount.Data.ORM.Entities
{
	public class T100_Users : BaseEntity
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}

