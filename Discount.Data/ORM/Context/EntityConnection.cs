using System;
using Discount.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Data.ORM.Context
{
	public class EntityConnection : DbContext
	{


        public EntityConnection(DbContextOptions<EntityConnection> options) : base(options)
        {

        }


        public DbSet<T100_User> T100_Users { get; set; }
        public DbSet<T200_Product> T200_Products {  get; set; } 
        public DbSet<T210_Basket> T201_Baskets { get; set; }
        public DbSet<T211_BasketProduct> T211_BasketProducts { get; set; }
        public DbSet<T201_Category> T201_Categories { get; set; }
        public DbSet<T300_Campaign> T300_Campaigns { get; set; }


    }
}

