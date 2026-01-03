using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class ProjectsModel(IQueryMediator mediator) : PageModel
{
  public List<ProjectEntity> Projects { get; set; }
  public PagesContentEntity Header { get; set; }

  public PagesContentEntity LearnMore { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    Projects = await mediator.QueryAsync(new GetAllProjectsQuery());
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Header = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("projects", "projects", convertedCulture));
    LearnMore = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("learnmore", "root", convertedCulture));
    return Page();
  }
}
