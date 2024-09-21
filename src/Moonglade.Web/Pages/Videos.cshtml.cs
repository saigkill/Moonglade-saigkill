using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
  public class VideosModel(IMediator mediator) : PageModel
  {
    public List<VideoEntity> Videos { get; set; }
    public PagesContentEntity VideosTitle { get; set; }
    public PagesContentEntity Held { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Videos = await mediator.Send(new GetAllVideoQuery());
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      VideosTitle = await mediator.Send(new GetPageContentByKeyValueQuery("videos", "videos", convertedCulture));
      Held = await mediator.Send(new GetPageContentByKeyValueQuery("held", "talks", convertedCulture));

      return Page();
    }
  }
}
