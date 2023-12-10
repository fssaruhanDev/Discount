using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Data.ORM.Entities
{
    public class T301_CampaingType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }

        public int TypeID { get; set; }

    }
}
