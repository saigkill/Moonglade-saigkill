using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
    public class TalksModel(IMediator mediator) : PageModel
    {
        public List<TalkEntity> Talks { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Talks = await mediator.Send(new GetAllTalkQuery());

            return Page();
        }
    }
}
