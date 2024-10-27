using Moonglade.Configuration;

namespace Moonglade.Core;

public record GetSocialLinkQuery(string name) : IRequest<SocialLink>;

public class GetSocialLinkQueryHandler(IBlogConfig blogConfig) : IRequestHandler<GetSocialLinkQuery, SocialLink>
{
  public Task<SocialLink> Handle(GetSocialLinkQuery request, CancellationToken ct)
  {
    var section = blogConfig.SocialLinkSettings;

    if (!section.IsEnabled)
    {
      return Task.FromResult(new SocialLink { });
    }

    var link = Array.Find(blogConfig.SocialLinkSettings.Links, e => e.Name == request.name);
    return Task.FromResult(link);
  }
}
