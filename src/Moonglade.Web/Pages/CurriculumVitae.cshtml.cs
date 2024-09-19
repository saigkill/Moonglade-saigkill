using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
    public class CurriculumVitaeModel(IMediator mediator) : PageModel
    {
        public List<CertificateEntity> Certificates { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Certificates = await mediator.Send(new GetAllCertificatesQuery());

            return Page();
        }
    }
}
