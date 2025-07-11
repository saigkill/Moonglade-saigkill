using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages;

public class ImpulsesModel(IMediator mediator) : PageModel
{
  public PagesContentEntity Impulses { get; set; }
  public PagesContentEntity ImpulsesSlogan { get; set; }
  public PagesContentEntity ImpulsesSeelsorge { get; set; }
  public PagesContentEntity ImpulsesSeelsorgeTitle { get; set; }
  public PagesContentEntity ImpulsesBibleTitle { get; set; }
  public PagesContentEntity ImpulsesBible { get; set; }
  public PagesContentEntity ImpulsesPsychologicalTitle { get; set; }
  public PagesContentEntity ImpulsesPsychological { get; set; }
  public PagesContentEntity ImpulsesLang { get; set; }
  public PagesContentEntity ImpulsesBookPastoral { get; set; }
  public PagesContentEntity ImpulsesBookBiblestudy { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Impulses = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-title", "impulse", convertedCulture));
    ImpulsesSlogan = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-slogan", "impulse", convertedCulture));
    ImpulsesSeelsorge = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-seelsorge", "impulse", convertedCulture));
    ImpulsesSeelsorgeTitle = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-seelsorge-title", "impulse", convertedCulture));
    ImpulsesBibleTitle = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-bible-title", "impulse", convertedCulture));
    ImpulsesBible = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-bible", "impulse", convertedCulture));
    ImpulsesPsychologicalTitle = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-psychological-title", "impulse", convertedCulture));
    ImpulsesPsychological = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-psychological", "impulse", convertedCulture));
    ImpulsesLang = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-lang", "impulse", convertedCulture));
    ImpulsesBookPastoral = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-book-pastoral", "impulse", convertedCulture));
    ImpulsesBookBiblestudy = await mediator.Send(new GetPageContentByKeyValueQuery("impulse-book-bible", "impulse", convertedCulture));

    return Page();
  }
}
