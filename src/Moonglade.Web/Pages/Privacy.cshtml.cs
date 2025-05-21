using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

using System.Globalization;

namespace Moonglade.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        public PagesContentEntity Privacy { get; set; }

        public async Task<IActionResult> OnGetAsync(IMediator mediator)
        {
            var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
            var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
            Privacy = await mediator.Send(new GetPageContentByKeyValueQuery("privacy-title", "privacy", convertedCulture));
            return Page();
        }
    }
}
