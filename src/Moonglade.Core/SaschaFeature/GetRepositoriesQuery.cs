using Moonglade.Configuration;
using Moonglade.Github.Client.Models;
using Moonglade.Github.Client.Services;

namespace Moonglade.Core.SaschaFeature;

public record GetAllRepositoriesQuery(SocialLink githubSocialLink) : IRequest<List<UserRepository>>;

public class GetAllRepositoriesQueryHandler(IGithubUserRepositoriesService service) : IRequestHandler<GetAllRepositoriesQuery, List<UserRepository>>
{
  public Task<List<UserRepository>> Handle(GetAllRepositoriesQuery request, CancellationToken ct)
  {
    var repos = service.GetUserRepositories(request.githubSocialLink);
    return repos;
  }
}
