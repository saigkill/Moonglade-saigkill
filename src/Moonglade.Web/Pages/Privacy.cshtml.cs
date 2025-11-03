using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class PrivacyModel : PageModel
{
  public PagesContentEntity Privacy { get; set; }
  private readonly IQueryMediator _mediator;

  public PrivacyModel(IQueryMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task<IActionResult> OnGetAsync()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Privacy = await _mediator.QueryAsync(new GetPageContentByKeyValueQuery("privacy-title", "privacy", convertedCulture));
    return Page();
  }
}
