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

    public async Task<IActionResult> OnGetAsync()
    {
      var culture = CultureInfo.CurrentCulture.Name;
      var convertedCulture = culture.FromStringToLanguage();
      Disclaimer1 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer1", "imprint", convertedCulture));
      Disclaimer2 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer2", "imprint", convertedCulture));
      Disclaimer3 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer3", "imprint", convertedCulture));
      Disclaimer4 = await mediator.Send(new GetPageContentByKeyValueQuery("disclaimer4", "imprint", convertedCulture));

      return Page();
    }
  }
}
