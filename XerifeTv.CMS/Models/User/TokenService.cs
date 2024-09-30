using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using XerifeTv.CMS.Models.User.Interfaces;

namespace XerifeTv.CMS.Models.User;

public sealed class TokenService(IConfiguration _configuration) : ITokenService
{
  public string GenerateToken(UserEntity user)
  {
    var key = _configuration["Jwt:Key"] ?? string.Empty;
    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var issuer = _configuration["Jwt:Issuer"];
    var audience = _configuration["Jwt:Audience"];

    var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

    var tokenClaims = new []
    {
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.Role, user.Role.ToString().ToLower()),
    };

    var tokenOptions = new JwtSecurityToken(
      issuer, 
      audience,
      tokenClaims,
      expires: DateTime.UtcNow.AddDays(30),
      signingCredentials: signInCredentials);

    return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
  }
}
