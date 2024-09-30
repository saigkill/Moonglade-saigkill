using Moonglade.Github.Client.Models;
using Moonglade.Github.Client.Services;

namespace Moonglade.Core.SaschaFeature;

public record GetAllRepositoriesQuery() : IRequest<List<UserRepository>>;

public class GetAllRepositoriesQueryHandler(IGithubUserRepositoriesService service) : IRequestHandler<GetAllRepositoriesQuery, List<UserRepository>>
{
  public Task<List<UserRepository>> Handle(GetAllRepositoriesQuery request, CancellationToken ct)
  {
    var repos = service.GetUserRepositories();
    return repos;
  }
}
