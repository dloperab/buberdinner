using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Service;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGeneration : IJwtTokenGeneration
{
  private readonly JwtSettings _jwtSettings;
  private readonly IDateTimeProvider _dateTimeProvider;

  public JwtTokenGeneration(IOptions<JwtSettings> jwtOptions, IDateTimeProvider dateTimeProvider)
  {
    _jwtSettings = jwtOptions.Value;
    _dateTimeProvider = dateTimeProvider;
  }

  public string GenerateToken(User user)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
      SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var securityToken = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
      claims: claims,
      signingCredentials: signingCredentials);

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}