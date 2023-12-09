using System;
using Discount.BLL.BASE;
using Discount.BLL.DTO.User;
using Discount.Data.ORM.Context;
using Discount.Data.ORM.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.BLL.LOGICS
{
    public class UserLogic : BaseLogic<T100_User>
    {

        public UserLogic(EntityConnection entityConnection)
        {
            db = entityConnection;
            _context = db.Set<T100_User>();
        }


        public async Task<UserDTO> Login(string username, string password)
        {
            T100_User usr = await _context.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password && x.IsActive ==true && x.IsDeleted == false);

            if (usr != null)
            {
                User user = new User()
                {
                    Name = usr.Name,
                    Surname = usr.Surname
                };
                UserDTO value = new UserDTO()
                {
                   User = user,
                   Status = "OK",
                   Code = "200"
                };
                return value;
            }
            else
            {
                UserDTO value = new UserDTO()
                {
                    Status = "Reject",
                    Code = "300"
                };
                return value;
            }
           
            throw new NotImplementedException();
        }
    }
}
