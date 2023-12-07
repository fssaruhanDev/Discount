using Discount.BLL.LOGICS;
using Discount.Data.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.BASE
{
    public class ServicesProvider : IDisposable
    {
        EntityConnection con;

        public ServicesProvider(EntityConnection _con)
        {
            this.con = _con;
        }

        private UserLogic _userLogic;

        public UserLogic UserServices => _userLogic ?? new UserLogic(con);
        //----------------------------------------------------------------------------------------
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}