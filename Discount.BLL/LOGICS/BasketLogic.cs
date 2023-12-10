using Discount.BLL.BASE;
using Discount.BLL.DTO;
using Discount.BLL.DTO.Basket;
using Discount.BLL.DTO.Product;
using Discount.Data.ORM.Context;
using Discount.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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


        public async Task<BaseDTO<Basket>> GetBasket(int id)
        {

            try
            {
                var basket = await _context.FirstOrDefaultAsync(x => x.UserID == id && x.IsDeleted == false && x.IsActive == true);

                if (basket == null)
                {
                    T210_Basket newBasket = new T210_Basket()
                    {
                        UserID = id,
                        IsDeleted = false,
                        IsActive = true,
                        Amount = 0,
                        Discount = false,
                        CreateDate = DateTime.Now
                    };
                    db.Add(newBasket);
                    db.SaveChanges();

                    BaseDTO<Basket> baseDTO = new BaseDTO<Basket>("200", "Success");
                    return baseDTO;
                }
                else
                {
                    var basketProduct = db.T211_BasketProducts.FirstOrDefault(x => x.BasketID == basket.ID);
                    if (basketProduct == null)
                    {
                        BaseDTO<Basket> baseDTO = new BaseDTO<Basket>("201", "Ürün Bulunamadı");
                        return baseDTO;
                    }
                    else
                    {
                        return GetBasketItem(basketProduct, basket, db);
                    }
               
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<BaseDTO<Basket>> AddBasketProduct(BasketProduct _basketProduct)
        {
            try
            {
                BaseDTO<Basket> basketDTO = new BaseDTO<Basket>();
                var basket = await _context.FirstOrDefaultAsync(x => x.UserID == _basketProduct.UserID && !x.IsDeleted && x.IsActive);
                var product = db.T200_Products.FirstOrDefault(x => x.ID == _basketProduct.ProductID && x.IsActive == true && x.IsDeleted == false);

                if (product == null)
                {
                    basketDTO.Status = "Ürün bulunamadı";
                    basketDTO.Code = "1000";
                    return basketDTO;
                }


                if (basket == null)
                {
                    T210_Basket newBasket = new T210_Basket()
                    {
                        UserID = _basketProduct.UserID,
                        IsDeleted = false,
                        IsActive = true,
                        Amount = 0,
                        Discount = false,
                        CreateDate = DateTime.Now
                    };
                    db.Add(newBasket);
                    db.SaveChanges();

                    T211_BasketProduct BasketProduct = new T211_BasketProduct()
                    {
                        BasketID = newBasket.ID,
                        ProductID = _basketProduct.ProductID,
                        ProductPrice = product.ProductPrice * _basketProduct.ProductQuantity,
                    };
                    if (StockCheck(product,_basketProduct.ProductQuantity))
                    {
                        BasketProduct.ProductQuantity = _basketProduct.ProductQuantity;
                    }
                    else
                    {
                        basketDTO.Status = "Stoktan Fazla Ürün";
                        basketDTO.Code = "1100";
                        return basketDTO;
                    }
                    db.Add(BasketProduct);
                    db.SaveChanges();

                    basketDTO.Status = "Success";
                    basketDTO.Code = "200";
                    return basketDTO;


                }
                else
                {

                    var _basketItemCheck = db.T211_BasketProducts.FirstOrDefault(x => x.ProductID == _basketProduct.ProductID && x.BasketID == basket.ID);

                    if (_basketItemCheck != null)
                    {
                        if (StockCheck(product, _basketProduct.ProductQuantity))
                        {
                            _basketItemCheck.ProductQuantity += _basketItemCheck.ProductQuantity;
                            db.SaveChanges();
                            basketDTO.Status = "Success";
                            basketDTO.Code = "200";
                            return basketDTO;
                        }
                        else
                        {
                            basketDTO.Status = "Stoktan Fazla Ürün";
                            basketDTO.Code = "1100";
                            return basketDTO;
                        }


                    }
                    else
                    {

                        T211_BasketProduct BasketProduct = new T211_BasketProduct()
                        {
                            BasketID = basket.ID,
                            ProductID = _basketProduct.ProductID,
                            ProductPrice = product.ProductPrice * _basketProduct.ProductQuantity,
                        };

                        if (StockCheck(product, _basketProduct.ProductQuantity))
                        {
                            BasketProduct.ProductQuantity = _basketProduct.ProductQuantity;
                        }
                        else
                        {
                            basketDTO.Status = "Stoktan Fazla Ürün";
                            basketDTO.Code = "1000";
                            return basketDTO;
                        }
                        db.Add(BasketProduct);
                        db.SaveChanges();
                        basketDTO.Status = "Success";
                        basketDTO.Code = "200";
                        return basketDTO;
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        static bool StockCheck(T200_Product _Product, int ProductQuantity)
        {
            var ProductQuantityCheck = ProductQuantity > _Product.ProductStock;
            if (!ProductQuantityCheck)
            {
                return true;
            }
            else { return false; }
        }


        static BaseDTO<Basket> GetBasketItem(T211_BasketProduct basketProduct, T210_Basket basket, EntityConnection db)
        {
            
            double productPrice = basketProduct?.ProductPrice ?? 0;
            var productQuantity = basketProduct?.ProductQuantity ?? 0;

            Basket getBasket = new Basket
            {
                ID = basket.ID,
                Amount = basket.Amount,
                Discount = basket.Amount >= 1000,
                
            };
            var _product = db.T200_Products.FirstOrDefault(x => x.ID == basketProduct.ProductID);
            var Product = basket.BasketProduct
                ?.Where(x => x.BasketID == basket.ID)
                .Select(bsk => new Product
                {
                    ID = _product.ID,
                    Description = bsk.Product.ProductDescription,
                    Name = _product.ProductName,
                    Price = basketProduct.ProductPrice,
                    Company = _product.ProductCompany,
                    Size = _product.ProductSize,
                    Stock = _product.ProductStock,
                    Quantity = productQuantity
                })
                .ToList();
            double _amount = 0;

            foreach (var item in Product)
            {
                _amount += item.Price;
            }
            getBasket.Amount = _amount;
            getBasket.Price = getBasket.Discount ? getBasket.Price * 0.90 : getBasket.Price;
            getBasket.Product = Product;

            BaseDTO<Basket> baseDTO = new BaseDTO<Basket>("200","Success",getBasket);

            return baseDTO;
        }
    }
}
