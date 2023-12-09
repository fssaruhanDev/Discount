using Discount.BLL.BASE;
using Discount.BLL.DTO.Basket;
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
    public class BasketLogic : BaseLogic<T210_Basket>
    {

        public BasketLogic(EntityConnection entityConnection)
        {
            db = entityConnection;
            _context = db.Set<T210_Basket>();
        }


        public async Task<BasketDTO<Basket>> GetBasket(int id)
        {
            try
            {
                BasketDTO<Basket> basketDTO = new();
                var basket = await _context.FirstOrDefaultAsync(x => x.UserID == id && x.IsDeleted == false && x.IsActive == true);

                if (basket == null)
                {
                    T210_Basket _Basket = new T210_Basket()
                    {
                        UserID = id,
                        IsDeleted = false,
                        IsActive = true,
                        Amount = 0,
                        Discount = false,
                        CreateDate = DateTime.Now
                    };
                    db.Add(_Basket);
                    db.SaveChanges();
                    Basket getBasket = new Basket();
                    getBasket.ID = _Basket.ID;

                    basketDTO.Basket = getBasket;
                    basketDTO.Status = "CreatedBasket";
                    basketDTO.Code = "200";

                }
                else
                {
                    double productPrice = (double)(basket.BasketProduct?.FirstOrDefault(x => x.BasketID == basket.ID) == null ? 0 : basket.BasketProduct?.FirstOrDefault(x => x.BasketID == basket.ID).ProductPrice);
                    var productQuantity = basket.BasketProduct?.FirstOrDefault(x => x.BasketID == basket.ID) == null ? 0 : basket.BasketProduct.FirstOrDefault(x => x.BasketID == basket.ID).ProductQuantity;
                    Basket getBasket = new Basket
                    {
                        ID = basket.ID,
                        Amount = basket.Amount,
                        Discount = basket.Amount >= 1000 ? true : false,
                        Quantity = productQuantity,
                        Price = productPrice,
                        Product = basket.BasketProduct?.Where(x => x.BasketID == basket.ID)
                        .Select(bsk => new Product()
                        {
                            ID = bsk.Product.ID,
                            Description = bsk.Product.ProductDescription,
                            Name = bsk.Product.ProductName,
                            Price = bsk.Product.ProductPrice,
                            Stock = bsk.Product.ProductStock

                        }).ToList()
                    };

                    basketDTO.Status = "Success";
                    basketDTO.Code = "200";
                    basketDTO.Basket = getBasket;


                }


                return basketDTO;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
