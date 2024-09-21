using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
  public class ImprintModel(IMediator mediator) : PageModel
  {
    public PagesContentEntity Disclaimer1 { get; set; }
    public PagesContentEntity Disclaimer2 { get; set; }
    public PagesContentEntity Disclaimer3 { get; set; }
    public PagesContentEntity Disclaimer4 { get; set; }
    public PagesContentEntity ImprintHeader { get; set; }
    public PagesContentEntity ImprintService { get; set; }
    public PagesContentEntity Contact { get; set; }
    public PagesContentEntity Socialmedia { get; set; }
    public PagesContentEntity Other { get; set; }
    public PagesContentEntity Liability { get; set; }
    public PagesContentEntity Disclaimer { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      Disclaimer1 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer1", "imprint", convertedCulture));
      Disclaimer2 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer2", "imprint", convertedCulture));
      Disclaimer3 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer3", "imprint", convertedCulture));
      Disclaimer4 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer4", "imprint", convertedCulture));
      ImprintHeader = await mediator.Send(new GetPageContentByKeyValueQuery("imprint-header", "imprint", convertedCulture));
      ImprintService = await mediator.Send(new GetPageContentByKeyValueQuery("imprint-service", "imprint", convertedCulture));
      Contact = await mediator.Send(new GetPageContentByKeyValueQuery("contact", "imprint", convertedCulture));
      Socialmedia = await mediator.Send(new GetPageContentByKeyValueQuery("socialmedia", "imprint", convertedCulture));
      Other = await mediator.Send(new GetPageContentByKeyValueQuery("other", "imprint", convertedCulture));
      Liability = await mediator.Send(new GetPageContentByKeyValueQuery("liability", "imprint", convertedCulture));
      Disclaimer = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer", "imprint", convertedCulture));

      return Page();
    }
  }
}
