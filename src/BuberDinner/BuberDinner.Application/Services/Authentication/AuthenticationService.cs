using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGeneration _jwtTokenGeneration;

    public AuthenticationService(IJwtTokenGeneration jwtTokenGeneration)
    {
        _jwtTokenGeneration = jwtTokenGeneration;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    // Check if the user exists

    // Create user (generate unique ID)
    var userId = Guid.NewGuid();

    // Create JWT token
    var token = _jwtTokenGeneration.GenerateToken(userId, firstName, lastName);

    return new AuthenticationResult(
      userId,
      firstName,
      lastName,
      email,
      token);
  }

  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(
      Guid.NewGuid(),
      "firstName",
      "lastName",
      email,
      "token");
  }
}