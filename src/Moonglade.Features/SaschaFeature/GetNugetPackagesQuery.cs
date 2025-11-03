using LiteBus.Queries.Abstractions;
using Moonglade.Nuget.Client;

namespace Moonglade.Features.SaschaFeature;

public record GetAllNugetPackagesQuery() : IQuery<List<NugetPackage>>;

public class GetAllNugetPackagesQueryHandler(INugetClient client) : IQueryHandler<GetAllNugetPackagesQuery, List<NugetPackage>>
{
  public Task<List<NugetPackage>> HandleAsync(GetAllNugetPackagesQuery request, CancellationToken ct)
  {
    var packages = client.SendRequestAsync();
    return packages;
  }
}

