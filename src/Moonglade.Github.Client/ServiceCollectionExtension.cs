using Microsoft.Extensions.DependencyInjection;

using Moonglade.Github.Client.Services;

namespace Moonglade.Github.Client;

public static class ServiceCollectionExtension
{
  public static IServiceCollection AddGithubClient(this IServiceCollection services)
  {
    services.AddScoped<IGithubClient, GithubClient>();
    services.AddScoped<IGithubUserRepositoriesService, GithubUserRepositoriesService>();
    return services;
  }
}
