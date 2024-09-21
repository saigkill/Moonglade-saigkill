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
    public PagesContentEntity Masterheaad { get; set; }
    public PagesContentEntity AboutName { get; set; }
    public PagesContentEntity AboutJob { get; set; }
    public PagesContentEntity AboutYear { get; set; }
    public PagesContentEntity AboutProgram { get; set; }
    public PagesContentEntity AboutYear1 { get; set; }
    public PagesContentEntity AboutExperience { get; set; }
    public PagesContentEntity SkillsTitle { get; set; }
    public PagesContentEntity AboutOtherSkills { get; set; }
    public PagesContentEntity ActivityAll { get; set; }
    public PagesContentEntity ActivityLast30 { get; set; }
    public PagesContentEntity JobsTitle { get; set; }
    public PagesContentEntity EducationTitle { get; set; }
    public PagesContentEntity PortfolioTitle { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Certificates = await mediator.Send(new GetAllCertificatesQuery());
      Testimonials = await mediator.Send(new GetAllTestimonialsQuery());

      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      Intro = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro", "curriculum_vitae", convertedCulture));
      Intro1 = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro1", "curriculum_vitae", convertedCulture));
      Intro2 = await mediator.Send(new GetPageContentByKeyValueQuery("cvintro2", "curriculum_vitae", convertedCulture));
      Masterheaad = await mediator.Send(new GetPageContentByKeyValueQuery("masterhead-lead", "curriculum_vitae", convertedCulture));
      AboutName = await mediator.Send(new GetPageContentByKeyValueQuery("about-name", "curriculum_vitae", convertedCulture));
      AboutJob = await mediator.Send(new GetPageContentByKeyValueQuery("about-jobs", "curriculum_vitae", convertedCulture));
      AboutYear = await mediator.Send(new GetPageContentByKeyValueQuery("about-year", "curriculum_vitae", convertedCulture));
      AboutProgram = await mediator.Send(new GetPageContentByKeyValueQuery("about-program", "curriculum_vitae", convertedCulture));
      AboutYear1 = await mediator.Send(new GetPageContentByKeyValueQuery("about-year1", "curriculum_vitae", convertedCulture));
      AboutExperience = await mediator.Send(new GetPageContentByKeyValueQuery("about-experience", "curriculum_vitae", convertedCulture));
      SkillsTitle = await mediator.Send(new GetPageContentByKeyValueQuery("skills-title", "curriculum_vitae", convertedCulture));
      AboutOtherSkills = await mediator.Send(new GetPageContentByKeyValueQuery("about-other-skills", "curriculum_vitae", convertedCulture));
      ActivityAll = await mediator.Send(new GetPageContentByKeyValueQuery("activity-all", "curriculum_vitae", convertedCulture));
      ActivityLast30 = await mediator.Send(new GetPageContentByKeyValueQuery("activity-last30", "curriculum_vitae", convertedCulture));
      JobsTitle = await mediator.Send(new GetPageContentByKeyValueQuery("jobs-title", "curriculum_vitae", convertedCulture));
      EducationTitle = await mediator.Send(new GetPageContentByKeyValueQuery("education-title", "curriculum_vitae", convertedCulture));
      PortfolioTitle = await mediator.Send(new GetPageContentByKeyValueQuery("portfolio-title", "curriculum_vitae", convertedCulture));
      return Page();
    }
  }
}
