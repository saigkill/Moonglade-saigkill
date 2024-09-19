using Microsoft.AspNetCore.Html;

namespace Moonglade.Web.Services;

public class DonationViewService
{
  private readonly IBlogConfig _blogConfig;

  public DonationViewService(IBlogConfig config)
  {
    _blogConfig = config;
  }

  private string BuildDonationString()
  {
    StringBuilder sb = new StringBuilder();
    sb.Append(@"<table class=""tg""><tbody><tr>");
    if (_blogConfig.SocialProfileSettings.BuyMeACoffee != null)
    {
      sb.Append($@"<td class=""tg-01ax""><i class=""fa-solid fa-mug-hot""></i><a href=""{_blogConfig.SocialProfileSettings.BuyMeACoffee}"" target=""_blank"" rel=""me""></a></td>");
    }

    if (_blogConfig.SocialProfileSettings.Liberapay != null)
    {
      sb.Append($@"<td class=""tg-01ax""><i class=""fa-solid fa-coins""></i><a href=""{_blogConfig.SocialProfileSettings.Liberapay}"" target=""_blank"" rel=""me""></a></td>");
    }

    if (_blogConfig.SocialProfileSettings.Patreon != null)
    {
      sb.Append($@"<td class=""tg-01ax""><i class=""fa-brands fa-patreon""></i><a href=""{_blogConfig.SocialProfileSettings.Patreon}"" target=""_blank"" rel=""me""></a></td>");
    }

    if (_blogConfig.SocialProfileSettings.AmazonWishlist != null)
    {
      sb.Append(
        $@"<td class=""tg-01ax""><i class=""fa-brands fa-amazon""></i><a href=""{_blogConfig.SocialProfileSettings.AmazonWishlist}"" target=""_blank"" rel=""me""></a></td>");
    }

    if (_blogConfig.SocialProfileSettings.Paypal != null)
    {
      sb.Append(
        $@"<td class=""tg-01ax""><i class=""fa-brands fa-paypal""></i><a href=""{_blogConfig.SocialProfileSettings.Paypal}"" target=""_blank"" rel=""me""></a></td>");
    }

    sb.Append(@"</tr></tbody></table>");

    return sb.ToString();
  }

  public HtmlString InlineAdd()
  {
    string donations = BuildDonationString();
    return new HtmlString(donations);
  }
}
