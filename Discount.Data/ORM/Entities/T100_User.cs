using System;
using Discount.Data.ORM.Base;

namespace Discount.Data.ORM.Entities
{
	public class T100_User : BaseEntity
	{

		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required string UserName { get; set; }
		public required string Password { get; set; }


        public List<T210_Basket>? Basket { get; set; }

    }
}

