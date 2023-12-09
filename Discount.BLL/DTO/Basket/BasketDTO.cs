using System;
namespace Discount.BLL.DTO.Basket
{
	public class BasketDTO<T>
    {

        public T Basket { get; set; }
        public string Status { get; set; }
		public string Code { get; set; }
    }
}

