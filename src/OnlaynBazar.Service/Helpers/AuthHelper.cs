﻿using Microsoft.IdentityModel.Tokens;
using OnlaynBazar.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlaynBazar.Service.Helpers;

public class AuthHelper
{
    public static string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(EnvironmentHelper.JWTKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim("PhoneNumber", user.PhoneNumber),
                 new Claim(ClaimTypes.Role, user.Role.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(EnvironmentHelper.TokenLifeTimeInHours)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
