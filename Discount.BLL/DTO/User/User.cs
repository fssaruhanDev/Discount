﻿using System;
namespace Discount.BLL.DTO.User
{
	public class User
	{
		public User()
		{
		}
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

