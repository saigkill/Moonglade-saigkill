using Moonglade.Nuget.Client;

namespace Moonglade.Core.SaschaFeature;

public record GetAllNugetPackagesQuery() : IRequest<List<NugetPackage>>;

public class GetAllNugetPackagesQueryHandler(INugetClient client) : IRequestHandler<GetAllNugetPackagesQuery, List<NugetPackage>>
{
  public Task<List<NugetPackage>> Handle(GetAllNugetPackagesQuery request, CancellationToken ct)
  {
    var packages = client.SendRequestAsync();
    return packages;
  }
}

