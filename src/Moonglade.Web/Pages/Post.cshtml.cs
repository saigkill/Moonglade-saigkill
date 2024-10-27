using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.PostFeature;
using Moonglade.Data.Entities;
using Moonglade.Pingback;

namespace Moonglade.Web.Pages;

[AddPingbackHeader("pingback")]
public class PostModel(IMediator mediator) : PageModel
{
  public PostEntity Post { get; set; }

  public SocialLink Twitter { get; set; }
  public SocialLink BuyMeACoffee { get; set; }
  public SocialLink Liberapay { get; set; }
  public SocialLink Patreon { get; set; }
  public SocialLink AmazonWishlist { get; set; }
  public SocialLink Paypal { get; set; }

  public async Task<IActionResult> OnGetAsync(int year, int month, int day, string slug)
  {

    Twitter = await mediator.Send(new GetSocialLinkQuery("Twitter"));
    BuyMeACoffee = await mediator.Send(new GetSocialLinkQuery("BuyMeACoffee"));
    Liberapay = await mediator.Send(new GetSocialLinkQuery("Liberapay"));
    Patreon = await mediator.Send(new GetSocialLinkQuery("Patreon"));
    AmazonWishlist = await mediator.Send(new GetSocialLinkQuery("AmazonWishlist"));

    if (year > DateTime.UtcNow.Year || string.IsNullOrWhiteSpace(slug)) return NotFound();

    var post = await mediator.Send(new GetPostBySlugQuery(year, month, day, slug));

    if (post is null) return NotFound();

    ViewData["TitlePrefix"] = $"{post.Title}";

    Post = post;
    return Page();
  }
}
