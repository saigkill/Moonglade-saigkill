using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;
using Moonglade.Data.Specifications;

namespace Moonglade.Web.Pages
{
  public class DemocraticYearModel(IMediator mediator) : PageModel
  {
    public List<TestimonialEntity> Testimonials { get; set; } = new();
    public PagesContentEntity ButtonWord { get; set; }
    public PagesContentEntity ButtonPdf { get; set; }
    public PagesContentEntity DownloadTaz { get; set; }
    public PagesContentEntity DownloadFaz { get; set; }
    public PagesContentEntity DownloadTagesspiegel { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Testimonials = await mediator.Send(new GetAllTestimonialsQuery(Audience.Demoyear));
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      ButtonWord = await mediator.Send(new GetPageContentByKeyValueQuery("word-download", "root", convertedCulture));
      ButtonPdf = await mediator.Send(new GetPageContentByKeyValueQuery("pdf-download", "root", convertedCulture));
      DownloadTaz = await mediator.Send(new GetPageContentByKeyValueQuery("taz-download", "demoyear", convertedCulture));
      DownloadFaz = await mediator.Send(new GetPageContentByKeyValueQuery("faz-download", "demoyear", convertedCulture));
      DownloadTagesspiegel = await mediator.Send(new GetPageContentByKeyValueQuery("tagesspiegel-download", "demoyear", convertedCulture));

      return Page();
    }
  }
}
