using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
  private static readonly List<User> _users = new();

  public User? GetUserByEmail(string email)
  {
    return _users.SingleOrDefault(x => x.Email.Equals(email));
  }

  public void Add(User user)
  {
    _users.Add(user);
  } 
}