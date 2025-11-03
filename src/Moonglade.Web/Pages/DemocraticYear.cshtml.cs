using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Data.Specifications;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages
{
  public class DemocraticYearModel(IQueryMediator mediator) : PageModel
  {
    public List<TestimonialEntity> Testimonials { get; set; } = new();
    public PagesContentEntity ButtonWord { get; set; }
    public PagesContentEntity ButtonPdf { get; set; }
    public PagesContentEntity DownloadTaz { get; set; }
    public PagesContentEntity DownloadFaz { get; set; }
    public PagesContentEntity DownloadTagesspiegel { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Testimonials = await mediator.QueryAsync(new GetAllTestimonialsQuery(Audience.Demoyear));
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      ButtonWord = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("word-download", "root", convertedCulture));
      ButtonPdf = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("pdf-download", "root", convertedCulture));
      DownloadTaz = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("taz-download", "demoyear", convertedCulture));
      DownloadFaz = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("faz-download", "demoyear", convertedCulture));
      DownloadTagesspiegel = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("tagesspiegel-download", "demoyear", convertedCulture));

      return Page();
    }
  }
}
