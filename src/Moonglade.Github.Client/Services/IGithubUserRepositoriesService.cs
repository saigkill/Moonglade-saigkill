using Moonglade.Configuration;
using Moonglade.Github.Client.Models;

namespace Moonglade.Github.Client.Services;

public interface IGithubUserRepositoriesService
{
    Task<List<UserRepository>> GetUserRepositories(string githubSocialLink);
}
