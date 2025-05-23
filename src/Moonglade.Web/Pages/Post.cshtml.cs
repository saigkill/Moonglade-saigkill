﻿using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.PostFeature;
using Moonglade.Data.Entities;
using Moonglade.Pingback;

namespace Moonglade.Web.Pages;

[AddPingbackHeader("pingback")]
public class PostModel(IConfiguration configuration, IMediator mediator) : PageModel
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
        Twitter = await mediator.Send(new GetSocialLinkQuery("Twitter"));
        BuyMeACoffee = await mediator.Send(new GetSocialLinkQuery("BuyMeACoffee"));
        Liberapay = await mediator.Send(new GetSocialLinkQuery("Liberapay"));
        Patreon = await mediator.Send(new GetSocialLinkQuery("Patreon"));
        AmazonWishlist = await mediator.Send(new GetSocialLinkQuery("AmazonWishlist"));
        Paypal = await mediator.Send(new GetSocialLinkQuery("Paypal"));
        if (year > DateTime.UtcNow.Year || string.IsNullOrWhiteSpace(slug)) return NotFound();

    var post = await mediator.Send(new GetPostBySlugQuery(year, month, day, slug));

    if (post is null) return NotFound();

        Post = post;
        ViewData["TitlePrefix"] = $"{Post.Title}";

        if (IsViewCountEnabled)
        {
            await mediator.Send(new AddRequestCountCommand(post.Id));
            PostView = await mediator.Send(new GetPostViewQuery(post.Id));
        }

        return Page();
    }
}