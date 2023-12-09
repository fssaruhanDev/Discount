using Discount.BLL.LOGICS;
using Discount.Data.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.BASE
{
    public class ServicesProvider(EntityConnection _con) : IDisposable
    {
        private UserLogic _userLogic;

        public UserLogic UserServices => _userLogic ?? new UserLogic(_con);

        private ProductLogic _ProductLogic;

        public ProductLogic ProductService => _ProductLogic ?? new ProductLogic(_con);

        private BasketLogic _basketLogic;

        public BasketLogic BasketService => _basketLogic ?? new BasketLogic(_con);
        //----------------------------------------------------------------------------------------
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

     
    }

}