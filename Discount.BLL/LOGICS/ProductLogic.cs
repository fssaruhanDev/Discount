using Discount.BLL.BASE;
using Discount.BLL.DTO.Product;
using Discount.Data.ORM.Context;
using Discount.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.LOGICS
{
    public class ProductLogic : BaseLogic<T200_Product>
    {

        public ProductLogic(EntityConnection entityConnection)
        {
            db = entityConnection;
            _context = db.Set<T200_Product>();
        }
        public async Task<ProductDTO<ProductList>> GetAll()
        {
            ProductDTO<ProductList> productDTO = new();
            var products = await _context.Where(x =>x.IsActive == true && x.IsDeleted == false)
                .Select(product => new ProductList(){
                    ID = product.ID,
                    Name = product.ProductName,
                    Description = product.ProductDescription,
                    Price = product.ProductPrice
                }).ToListAsync();

            if (products != null)
            {
                productDTO.Product = products;
                productDTO.Status = "Success";
                productDTO.Code = "200";

                return productDTO;
            }
            else
            {
                productDTO.Status = "Success";
                productDTO.Code = "200";

                return productDTO;
            }

        }

        public async Task<ProductDTO<Product>> GetProduct(int id)
        {
            ProductDTO<Product> productDTO = new();
            var getProduct = await _context.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true && x.IsDeleted == false);
            Product product = new Product()
            {
                Description = getProduct.ProductDescription,
                Price = getProduct.ProductPrice,
                ID = getProduct.ID,
                Name = getProduct.ProductName,
                Stock = getProduct.ProductStock
            };
            List<Product> productList = new List<Product>();
            productList.Add(product);


            if (getProduct != null)
            {
                productDTO.Product = productList;
                productDTO.Status = "Success";
                productDTO.Code = "200";

                return productDTO;
            }
            else
            {
                productDTO.Status = "Success";
                productDTO.Code = "200";

                return productDTO;
            }

        }


    }
}
