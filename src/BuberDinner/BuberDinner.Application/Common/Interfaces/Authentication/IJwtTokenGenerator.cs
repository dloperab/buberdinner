using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGeneration
{
  string GenerateToken(User user);
}