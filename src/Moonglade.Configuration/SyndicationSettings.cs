namespace Moonglade.Configuration
{
  public class SyndicationSettings
  {
    public NetvibesSettings Netvibes { get; set; } = new();
    public BlogaramaSettings Blogarama { get; set; } = new();
    public OntoplistSettings Ontoplist { get; set; } = new();
    public TopblogsSettings Topblogs { get; set; } = new();
  }

  public class NetvibesSettings
  {
    public bool Enabled { get; set; }
    public string Url { get; set; } = "";
  }

  public class BlogaramaSettings
  {
    public bool Enabled { get; set; }
    public string Url { get; set; } = "";
    public string ID { get; set; } = "";
  }

  public class OntoplistSettings
  {
    public bool Enabled { get; set; }
    public string Url { get; set; } = "";
    public string ID { get; set; } = "";
  }

  public class TopblogsSettings
  {
    public bool Enabled { get; set; }
    public string ID { get; set; } = "";
  }
}
