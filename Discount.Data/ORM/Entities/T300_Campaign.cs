using Discount.Data.ORM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Data.ORM.Entities
{
    public class T300_Campaign:BaseEntity
    {
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public string CompaingType { get; set; } 
        public string CampaignDiscountRate { get; set; }
        public string CompaingCondition{ get; set; }
        public double CompaingQuantity { get; set; }
        public DateTime CompaingStartDate { get; set; }
        public DateTime CompaingEndDate { get; set; }

    }
}
