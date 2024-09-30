using System.Globalization;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Core.SaschaFeature;
using Moonglade.Data.Entities;
using Moonglade.Github.Client.Models;

namespace Moonglade.Web.Pages
{
  public class AboutModel(IMediator mediator) : PageModel
  {
    public AboutViewModel ViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      ViewModel = new AboutViewModel();
      ViewModel.Memberships = await mediator.Send(new GetAllMembershipQuery());
      ViewModel.Mandates = await mediator.Send(new GetAllMandatesQuery());
      ViewModel.HonoraryPositions = await mediator.Send(new GetHonoraryPositionsByLanguageQuery());
      ViewModel.Publications = await mediator.Send(new GetAllPublicationsQuery());
      ViewModel.Repositories = await mediator.Send(new GetAllRepositoriesQuery());
      var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
      var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
      ViewModel.MeAnTheBlog =
        await mediator.Send(new GetPageContentByKeyValueQuery("me-and-blog", "about", convertedCulture));
      ViewModel.CoatOfArms =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-coat-of-arms", "about", convertedCulture));
      ViewModel.Connect =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-connect", "about", convertedCulture));
      ViewModel.AboutMemberships =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-memberships", "about", convertedCulture));
      ViewModel.AboutMandates =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-mandates", "about", convertedCulture));
      ViewModel.AboutHonoraryPositions =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-hpos", "about", convertedCulture));
      ViewModel.AboutPublications =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-publications", "about", convertedCulture));
      ViewModel.AboutRepositories =
        await mediator.Send(new GetPageContentByKeyValueQuery("about-opensource", "about", convertedCulture));
      ViewModel.LastUpdated = await mediator.Send(new GetPageContentByKeyValueQuery("last-updated", "about", convertedCulture));
      ViewModel.NugetTitle = await mediator.Send(new GetPageContentByKeyValueQuery("nuget", "about", convertedCulture));
      ViewModel.NugetPackages = await mediator.Send(new GetAllNugetPackagesQuery());
      return Page();
    }
  }

  public class AboutViewModel
  {
    public List<MembershipEntity> Memberships { get; set; }
    public List<MandateEntity> Mandates { get; set; }
    public List<HonoraryPositionEntity> HonoraryPositions { get; set; }
    public List<PublicationEntity> Publications { get; set; }
    public List<UserRepository> Repositories { get; set; }
    public PagesContentEntity MeAnTheBlog { get; set; }
    public PagesContentEntity CoatOfArms { get; set; }
    public PagesContentEntity Connect { get; set; }
    public PagesContentEntity AboutMemberships { get; set; }
    public PagesContentEntity AboutMandates { get; set; }
    public PagesContentEntity AboutHonoraryPositions { get; set; }
    public PagesContentEntity AboutPublications { get; set; }
    public PagesContentEntity AboutRepositories { get; set; }
    public PagesContentEntity LastUpdated { get; set; }
    public PagesContentEntity NugetTitle { get; set; }
    public List<NugetPackage> NugetPackages { get; set; }
  }
}
