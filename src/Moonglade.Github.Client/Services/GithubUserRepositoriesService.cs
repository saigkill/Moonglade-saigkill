using Microsoft.Extensions.Logging;

using Moonglade.Configuration;
using Moonglade.Github.Client.Models;

using Newtonsoft.Json;

using RestSharp;

namespace Moonglade.Github.Client.Services;

public class GithubUserRepositoriesService : IGithubUserRepositoriesService
{
  private readonly string _ghUser;
  private readonly ILogger<GithubUserRepositoriesService> _logger;
  private readonly IGithubClient _githubClient;

  public GithubUserRepositoriesService(IBlogConfig blogConfig, IGithubClient githubClient, ILogger<GithubUserRepositoriesService> logger)
  {
    var ghProfileLink = blogConfig.SocialProfileSettings.GitHub;
    _ghUser = ghProfileLink?.Replace("https://github.com/", "");
    _githubClient = githubClient;
    _logger = logger;
  }

  public async Task<List<UserRepository>> GetUserRepositories()
  {
    try
    {
      var endpoint = $"/users/{_ghUser}/repos";
      var ghResponse = await _githubClient.SendRequest(Method.Get, endpoint, "");
      _logger.LogInformation("Github response: {0}", ghResponse.Content);
      var repositories = JsonConvert.DeserializeObject<List<UserRepository>>(ghResponse.Content);
      foreach (var repo in repositories)
      {
        if (string.IsNullOrEmpty(repo.HtmlUrl))
        {
          repo.HtmlUrl = $"https://github.com/{_ghUser}/{repo.Name}";
        }
      }
      return repositories;
    }
    catch (Exception exception)
    {
      _logger.LogError(exception, "Error while fetching user repositories from Github. Error: {Message}", exception.Message);
      throw;
    }
  }
}
