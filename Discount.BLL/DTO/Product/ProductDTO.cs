using System;
namespace Discount.BLL.DTO.Product
{
	public class ProductDTO<T>
	{
        public ProductDTO()
        {
            
        }
        public List<T> Product { get; set; }
		public string Status { get; set; }
		public string Code { get; set; }
    }
}

