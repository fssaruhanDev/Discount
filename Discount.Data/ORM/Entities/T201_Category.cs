using Discount.Data.ORM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Data.ORM.Entities
{
    public class T201_Category 
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        List<T200_Product> Products { get; set; }
        List<T300_Campaign> Campaigns { get; set; }
    }
}
