using Discount.BLL.DTO.Basket;
using System;
namespace Discount.Security
{
	public class Token
	{
		public string AccessToken { get; set; }

		public string RefreshToken { get; set; }

		public DateTime Expiration { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int ID { get; set; }

        public BasketDTO<Basket> Basket{ get; set; }


    }
}

