using Microsoft.Extensions.DependencyInjection;

namespace Moonglade.Nuget.Client;

public static class ServiceCollectionExtension
{
  public static IServiceCollection AddNugetClient(this IServiceCollection services)
  {
    services.AddScoped<INugetClient, NugetClient>();
    return services;
  }
}
