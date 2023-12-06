using System;
namespace Discount.Security
{
	public class Token
	{
		public Token()
		{
		

		}

		public string AccessToken { get; set; }

		public string RefreshToken { get; set; }

		public DateTime Expiration { get; set; }

	}
}

