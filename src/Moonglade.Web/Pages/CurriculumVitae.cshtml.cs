using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
  public class CurriculumVitaeModel(IMediator mediator) : PageModel
  {
    public List<CertificateEntity> Certificates { get; set; }
    public List<TestimonialEntity> Testimonials { get; set; }
    public PagesContentEntity Intro { get; set; }
    public PagesContentEntity Intro1 { get; set; }
    public PagesContentEntity Intro2 { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Certificates = await mediator.Send(new GetAllCertificatesQuery());
      Testimonials = await mediator.Send(new GetAllTestimonialsQuery());

      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      Intro = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro", "curriculum_vitae", convertedCulture));
      Intro1 = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro1", "curriculum_vitae", convertedCulture));
      Intro2 = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro2", "curriculum_vitae", convertedCulture));

      return Page();
    }
  }
}
