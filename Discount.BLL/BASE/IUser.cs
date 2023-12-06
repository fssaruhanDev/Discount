using System;
using System.Reflection.Metadata;
using Discount.BLL.DTO.User;

namespace Discount.BLL.BASE
{
	public interface IUser
    {

        List<UserDTO> get();
        UserDTO Login(string username,string password);


    }
}

