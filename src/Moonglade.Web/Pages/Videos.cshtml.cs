using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class VideosModel(IQueryMediator mediator) : PageModel
{
  public List<VideoEntity> Videos { get; set; }
  public PagesContentEntity VideosTitle { get; set; }
  public PagesContentEntity Held { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    Videos = await mediator.QueryAsync(new GetAllVideoQuery());
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    VideosTitle = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("videos", "videos", convertedCulture));
    Held = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("held", "talks", convertedCulture));

    return Page();
  }
}
