using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Discount.Security
{
	public static class TokenHandler
	{

		public static Token  CreateToken(IConfiguration configuration)
		{
            Token token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt32(configuration["Token:Exparition"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            Random random = new Random();
            byte[] number = new byte[32];
            random.NextBytes(number);
            token.RefreshToken = Convert.ToBase64String(number);

            return token;
            
		}


	}
}

