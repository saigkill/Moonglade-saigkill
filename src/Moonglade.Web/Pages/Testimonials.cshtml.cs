using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;

namespace Moonglade.Web.Pages
{
    public class TestimonialsModel(IMediator mediator) : PageModel
    {
        public List<TestimonialEntity> Testimonials { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Testimonials = await mediator.Send(new GetAllTestimonialsQuery());

            return Page();
        }
    }
}
