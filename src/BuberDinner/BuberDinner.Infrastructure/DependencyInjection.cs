using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Service;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using BuberDinner.Infrastructure.Persistence;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
      this IServiceCollection services,
      ConfigurationManager configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    
    services.AddSingleton<IJwtTokenGeneration, JwtTokenGeneration>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}