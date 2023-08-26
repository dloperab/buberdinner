namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGeneration
{
  string GenerateToken(Guid userId, string firstName, string lastName);
}