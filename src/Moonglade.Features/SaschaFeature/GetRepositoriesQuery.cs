using LiteBus.Queries.Abstractions;
using Moonglade.Configuration;
using Moonglade.Github.Client.Models;
using Moonglade.Github.Client.Services;

namespace Moonglade.Features.SaschaFeature;

public record GetAllRepositoriesQuery(SocialLink githubSocialLink) : IQuery<List<UserRepository>>;

public class GetAllRepositoriesQueryHandler(IGithubUserRepositoriesService service) : IQueryHandler<GetAllRepositoriesQuery, List<UserRepository>>
{
  public Task<List<UserRepository>> HandleAsync(GetAllRepositoriesQuery request, CancellationToken ct)
  {
    var repos = service.GetUserRepositories(request.githubSocialLink);
    return repos;
  }
}
