using Newtonsoft.Json;

public class PackageType
{
  public string name { get; set; }
}

public class NugetPackage
{
  [JsonProperty("@id")]
  public string id { get; set; }

  [JsonProperty("@type")]
  public string type { get; set; }
  public string registration { get; set; }
  [JsonProperty("id")]
  public string idpackage { get; set; }
  public string version { get; set; }
  public string description { get; set; }
  public string summary { get; set; }
  public string title { get; set; }
  public string licenseUrl { get; set; }
  public string projectUrl { get; set; }
  public List<string> tags { get; set; }
  public List<string> authors { get; set; }
  public List<string> owners { get; set; }
  public int totalDownloads { get; set; }
  public bool verified { get; set; }
  public List<PackageType> packageTypes { get; set; }
  public List<Version> versions { get; set; }
  public List<object> vulnerabilities { get; set; }
  public string iconUrl { get; set; }
}

public class Version
{
  public string version { get; set; }
  public int downloads { get; set; }

  [JsonProperty("@id")]
  public string id { get; set; }
}
