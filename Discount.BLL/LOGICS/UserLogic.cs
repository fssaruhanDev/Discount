using System;
using Discount.BLL.BASE;
using Discount.BLL.DTO.User;
using Discount.Data.ORM.Context;
using Discount.Data.ORM.Entities;

namespace Discount.BLL.LOGICS
{
    public class UserLogic : IUser
    {

        EntityConnection db = new EntityConnection();

        public UserLogic()
        {
            
        }

        public List<UserDTO> get()
        {
            throw new NotImplementedException();
        }

        public UserDTO Login(string username, string password)
        {
            T100_Users usr = db.T100_Users.FirstOrDefault(x => x.UserName == username && x.Password == password && x.IsActive == true && x.IsDeleted == false);

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
                    Code = "200"
                };
                return value;
            }
           
            throw new NotImplementedException();
        }
    }
}
