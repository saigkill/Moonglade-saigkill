using Microsoft.Extensions.Logging;

using Moonglade.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moonglade.Nuget.Client;

public class NugetClient : INugetClient
{
    private readonly ILogger<NugetClient> _logger;
    private readonly IBlogConfig _config;

    public NugetClient(ILogger<NugetClient> logger, IBlogConfig config)
    {
        _logger = logger;
        _config = config;
    }

    public async Task<List<NugetPackage>?> SendRequestAsync()
    {
        if (_config.GeneralSettings == null)
        {
            _logger.LogError("GeneralSettings is null in the configuration.");
            throw new InvalidOperationException("GeneralSettings cannot be null.");
        }

        string username = _config.GeneralSettings.NugetUser;

        if (string.IsNullOrEmpty(username))
        {
            _logger.LogError("NugetUser is null or empty in the configuration.");
            throw new InvalidOperationException("NugetUser cannot be null or empty.");
        }

        string url = $"https://api.nuget.org/v3/index.json";
        var client = new HttpClient();
        var response = await client.GetStringAsync(url);
        var json = JObject.Parse(response);

        // Finden der URL für die Paket-Suche
        var searchQueryService = json["resources"]!
          .First(x => x["@type"]!.ToString() == "SearchQueryService");
        var searchUrl = searchQueryService["@id"]!.ToString();

        // Abrufen der Pakete für den angegebenen Benutzer
        var packagesUrl = $"{searchUrl}?q=owner:{username}&prerelease=false";
        var packagesResponse = await client.GetStringAsync(packagesUrl);
        var packagesJson = JObject.Parse(packagesResponse);
        var toDeserialize = packagesJson["data"];
        if (toDeserialize == null)
        {
            _logger.LogError("No data found in the response.");
            throw new InvalidOperationException("No data found in the response.");
        }
        var converted = toDeserialize.ToString();
        var packages = JsonConvert.DeserializeObject<List<NugetPackage>>(converted);

        return packages;
    }
}
