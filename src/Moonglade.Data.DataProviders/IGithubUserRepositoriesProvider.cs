using Moonglade.Configuration;
using Moonglade.Data.ExternalAPI.GitHub.Models;

namespace Moonglade.Data.DataProviders;

public interface IGithubUserRepositoriesProvider
{
	Task<List<UserReposResponse.Root>> GetUserRepositories();
}
