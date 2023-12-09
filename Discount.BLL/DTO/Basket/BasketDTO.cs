using System;
namespace Discount.BLL.DTO.Basket
{
	public class BasketDTO
    {
		public BasketDTO()
		{
		}

		public Basket User { get; set; }
		public string Status { get; set; }
		public string Code { get; set; }
    }
}

