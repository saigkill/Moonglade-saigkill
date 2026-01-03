using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class TalksModel(IQueryMediator mediator) : PageModel
{
  public List<TalkEntity> Talks { get; set; }
  public PagesContentEntity Intro { get; set; }
  public PagesContentEntity Slides { get; set; }
  public PagesContentEntity Held { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    Talks = await mediator.QueryAsync(new GetAllTalkQuery());
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Intro = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("talks", "talks", convertedCulture));
    Slides = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("slides", "talks", convertedCulture));
    Held = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("held", "talks", convertedCulture));

    return Page();
  }
}
