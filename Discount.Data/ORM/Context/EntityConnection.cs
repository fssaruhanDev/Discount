using System;
using Discount.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Data.ORM.Context
{
	public class EntityConnection : DbContext
	{


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=db.hoopkapida.com;Database=DiscountDB;User=fssaruhan;Password=123321Asd;TrustServerCertificate=True;Pooling=true;");
        }


        public DbSet<T100_Users> T100_Users { get; set; }
        public DbSet<T200_Product> T200_Products { get; set; }
        public DbSet<T201_Basket> T201_Baskets { get; set; }


    }
}

