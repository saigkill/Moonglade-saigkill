using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.Post;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class PostModel(
    IConfiguration configuration,
    ICacheAside cache,
    IQueryMediator queryMediator,
    ICommandMediator commandMediator) : PageModel
{
  public PostEntity Post { get; set; }
  public SocialLink Twitter { get; set; }
  public SocialLink BuyMeACoffee { get; set; }
  public SocialLink Liberapay { get; set; }
  public SocialLink Patreon { get; set; }
  public SocialLink AmazonWishlist { get; set; }
  public SocialLink Paypal { get; set; }
  public PostViewEntity PostView { get; set; }

    public bool IsViewCountEnabled { get; } = configuration.GetValue<bool>("Post:EnableViewCount");

    public async Task<IActionResult> OnGetAsync(int year, int month, int day, string slug)
    {
        Twitter = await queryMediator.QueryAsync(new GetSocialLinkQuery("Twitter"));
        BuyMeACoffee = await queryMediator.QueryAsync(new GetSocialLinkQuery("BuyMeACoffee"));
        Liberapay = await queryMediator.QueryAsync(new GetSocialLinkQuery("Liberapay"));
        Patreon = await queryMediator.QueryAsync(new GetSocialLinkQuery("Patreon"));
        AmazonWishlist = await queryMediator.QueryAsync(new GetSocialLinkQuery("AmazonWishlist"));
        Paypal = await queryMediator.QueryAsync(new GetSocialLinkQuery("Paypal"));
        if (year > DateTime.UtcNow.Year || string.IsNullOrWhiteSpace(slug)) return NotFound();

        var routeLink = $"{year}/{month}/{day}/{slug}".ToLower();

        var psm = await cache.GetOrCreateAsync(BlogCachePartition.Post.ToString(), $"{routeLink}", async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(int.Parse(configuration["Post:CacheMinutes"]!));

            var post = await queryMediator.QueryAsync(new GetPostBySlugQuery(routeLink));
            return post;
        });

        if (psm is null) return NotFound();

        Post = psm;
        ViewData["TitlePrefix"] = $"{Post.Title}";

        if (IsViewCountEnabled)
        {
            await commandMediator.SendAsync(new AddRequestCountCommand(psm.Id));
            PostView = await queryMediator.QueryAsync(new GetPostViewQuery(psm.Id));
        }

        return Page();
    }
}
