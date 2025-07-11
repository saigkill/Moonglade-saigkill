using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages;

public class ProjectsModel(IMediator mediator) : PageModel
{
  public List<ProjectEntity> Projects { get; set; }
  public PagesContentEntity Header { get; set; }

  public PagesContentEntity LearnMore { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    Projects = await mediator.Send(new GetAllProjectsQuery());
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Header = await mediator.Send(new GetPageContentByKeyValueQuery("projects", "projects", convertedCulture));
    LearnMore = await mediator.Send(new GetPageContentByKeyValueQuery("learnmore", "root", convertedCulture));
    return Page();
  }
}
