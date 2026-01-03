using System.Globalization;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moonglade.Data.Entities;
using Moonglade.Features.SaschaFeature;

namespace Moonglade.Web.Pages;

public class ConfirmBookingModel(IQueryMediator mediator) : PageModel
{
  public PagesContentEntity Title { get; set; }
  public PagesContentEntity Body { get; set; }

  public async Task<IActionResult> OnGetAsync()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
    Title = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("confirm-booking-title", "confirm-booking", convertedCulture));
    Body = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("confirm-booking-body", "confirm-booking", convertedCulture));

    return Page();
  }
}
