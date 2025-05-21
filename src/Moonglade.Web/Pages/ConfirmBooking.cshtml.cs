using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

using System.Globalization;

namespace Moonglade.Web.Pages
{
    public class ConfirmBookingModel(IMediator mediator) : PageModel
    {
        public PagesContentEntity Title { get; set; }
        public PagesContentEntity Body { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
            var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
            Title = await mediator.Send(new GetPageContentByKeyValueQuery("confirm-booking-title", "confirm-booking", convertedCulture));
            Body = await mediator.Send(new GetPageContentByKeyValueQuery("confirm-booking-body", "confirm-booking", convertedCulture));

            return Page();
        }
    }
}
