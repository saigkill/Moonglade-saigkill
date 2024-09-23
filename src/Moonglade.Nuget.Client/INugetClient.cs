namespace Moonglade.Nuget.Client;

public interface INugetClient
{

  public Task<List<NugetPackage>?> SendRequestAsync();
}
