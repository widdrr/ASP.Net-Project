﻿using Backend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Helpers.Authorization
{
    public class JwtUtility : IJwtUtility
    {
        private readonly JwtConfig _jwtConfig;

        public JwtUtility(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecret = Encoding.ASCII.GetBytes(_jwtConfig.JwtSecret!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecret), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public Guid ValidateToken(string token)
        {
            if (token == null)
            {
                return Guid.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(_jwtConfig.JwtSecret!);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };

            try
            {
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = new Guid(jwtToken.Claims.FirstOrDefault(x => x.Type == "id")!.Value);

                return userId;
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
