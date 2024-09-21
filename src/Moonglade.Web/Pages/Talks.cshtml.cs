using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
  public class TalksModel(IMediator mediator) : PageModel
  {
    public List<TalkEntity> Talks { get; set; }
    public PagesContentEntity Intro { get; set; }
    public PagesContentEntity Slides { get; set; }
    public PagesContentEntity Held { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Talks = await mediator.Send(new GetAllTalkQuery());
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      Intro = await mediator.Send(new GetPageContentByKeyValueQuery("talks", "talks", convertedCulture));
      Slides = await mediator.Send(new GetPageContentByKeyValueQuery("slides", "talks", convertedCulture));
      Held = await mediator.Send(new GetPageContentByKeyValueQuery("held", "talks", convertedCulture));

      return Page();
    }
  }
}
