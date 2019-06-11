using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OneBlink.SDK
{
    internal class Token
    {
        internal static string GenerateJSONWebToken(string accessKey, string secretKey, int expiryInSeconds)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(accessKey,
                accessKey,
                null,
                expires: DateTime.Now.AddSeconds(expiryInSeconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}