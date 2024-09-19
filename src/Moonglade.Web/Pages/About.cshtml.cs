using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;
using Moonglade.Github.Client.Models;
using Moonglade.Web.Services;

namespace Moonglade.Web.Pages
{
  public class AboutModel(IMediator mediator, IGithubUserRepositoriesService ghRepositoriesService) : PageModel
  {
    public List<MembershipEntity> Memberships { get; set; }
    public List<MandateEntity> Mandates { get; set; }
    public List<HonoraryPositionEntity> HonoraryPositions { get; set; }
    public List<PublicationEntity> Publications { get; set; }
    public List<UserRepository> Repositories { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      Memberships = await mediator.Send(new GetAllMembershipQuery());
      Mandates = await mediator.Send(new GetAllMandatesQuery());
      HonoraryPositions = await mediator.Send(new GetHonoraryPositionsByLanguageQuery());
      Publications = await mediator.Send(new GetAllPublicationsQuery());
      Repositories = await ghRepositoriesService.GetUserRepositories();
      return Page();
    }
  }
}
