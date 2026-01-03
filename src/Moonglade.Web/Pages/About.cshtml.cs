using System.Globalization;

using LiteBus.Queries.Abstractions;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Moonglade.Data.Entities;
using Moonglade.Data.Specifications;
using Moonglade.Features.SaschaFeature;
using Moonglade.Github.Client.Models;

namespace Moonglade.Web.Pages;

public class AboutModel(IQueryMediator mediator) : PageModel
{
    public AboutViewModel ViewModel { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        ViewModel = new AboutViewModel();
        ViewModel.Memberships = await mediator.QueryAsync(new GetAllMembershipQuery());
        ViewModel.Mandates = await mediator.QueryAsync(new GetAllMandatesQuery());
        ViewModel.HonoraryPositions = await mediator.QueryAsync(new GetHonoraryPositionsByLanguageQuery());
        ViewModel.Publications = await mediator.QueryAsync(new GetAllPublicationsQuery());
        var ghUserLink = "https://github.com/saigkill";
        ViewModel.Repositories = await mediator.QueryAsync(new GetAllRepositoriesQuery(ghUserLink));
        var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
        var convertedCulture = LanguageExtensions.FromLangCodeToLang(langCode);
        ViewModel.MeAnTheBlog =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("me-and-blog", "about", convertedCulture));
        ViewModel.CoatOfArms =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-coat-of-arms", "about", convertedCulture));
        ViewModel.Connect =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-connect", "about", convertedCulture));
        ViewModel.AboutMemberships =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-memberships", "about", convertedCulture));
        ViewModel.AboutMandates =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-mandates", "about", convertedCulture));
        ViewModel.AboutHonoraryPositions =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-hpos", "about", convertedCulture));
        ViewModel.AboutPublications =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-publications", "about", convertedCulture));
        ViewModel.AboutRepositories =
          await mediator.QueryAsync(new GetPageContentByKeyValueQuery("about-opensource", "about", convertedCulture));
        ViewModel.LastUpdated = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("last-updated", "about", convertedCulture));
        ViewModel.NugetTitle = await mediator.QueryAsync(new GetPageContentByKeyValueQuery("nuget", "about", convertedCulture));
        ViewModel.NugetPackages = await mediator.QueryAsync(new GetAllNugetPackagesQuery());
        ViewModel.Testimonials = await mediator.QueryAsync(new GetAllTestimonialsQuery(Audience.Testimonials));
        //ViewModel.SocialLinks = await mediator.Send(new GetSocialLinkQuery());
        return Page();
    }
}

public class AboutViewModel
{
    public List<MembershipEntity> Memberships { get; set; }
    public List<MandateEntity> Mandates { get; set; }
    public List<TestimonialEntity> Testimonials { get; set; }
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
    //public SocialLink[] SocialLinks { get; set; }
}
