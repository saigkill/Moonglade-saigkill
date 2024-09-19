using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
    public class VideosModel(IMediator mediator) : PageModel
    {
        public List<VideoEntity> Videos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Videos = await mediator.Send(new GetAllVideoQuery());

            return Page();
        }
    }
}
