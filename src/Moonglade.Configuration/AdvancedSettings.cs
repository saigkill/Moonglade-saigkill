using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Moonglade.Configuration;

public class AdvancedSettings : IBlogSettings
{
    [Display(Name = "robots.txt")]
    [DataType(DataType.MultilineText)]
    [MaxLength(1024)]
    public string RobotsTxtContent { get; set; }

    [Display(Name = "Enable Pingback send")]
    public bool EnablePingbackSend { get; set; } = true;

    [Display(Name = "Enable Pingback receive")]
    public bool EnablePingbackReceive { get; set; } = true;

    [Display(Name = "Enable MetaWeblog API")]
    public bool EnableMetaWeblog { get; set; } = true;

    [Display(Name = "Enable OpenSearch")]
    public bool EnableOpenSearch { get; set; } = true;

    [Display(Name = "Enable FOAF")]
    public bool EnableFoaf { get; set; } = true;

    [Display(Name = "Enable OPML")]
    public bool EnableOpml { get; set; } = true;

    [Display(Name = "Enable Site Map")]
    public bool EnableSiteMap { get; set; } = true;

    [MinLength(8), MaxLength(16)]
    [Display(Name = "MetaWeblog password")]
    public string MetaWeblogPassword { get; set; }

    [Display(Name = "Show warning when clicking external links")]
    public bool WarnExternalLink { get; set; }

    [Display(Name = "Allow javascript in pages")]
    public bool AllowScriptsInPage { get; set; }

    public string MetaWeblogPasswordHash { get; set; }

    [Display(Name = "Enable Syndication")]
    public bool EnableSyndication { get; set; } = true;

    [Display(Name = "Your Netvibes Url")]
    public string NetvibesUrl { get; set; }

    [Display(Name = "Your Blogarama Url")]
    public string BlogaramaUrl { get; set; }

    [Display(Name = "Enable Bloggerei")]
    public bool BloggereiEnabled { get; set; }

    [Display(Name = "Enable Bloggingfusion")]
    public bool BloggingfusionEnabled { get; set; }

    [Display(Name = "Enable Bloggeramt")]
    public bool BloggeramtEnabled { get; set; }

    [Display(Name = "Enable Topblogs")]
    public bool TopblogsEnabled { get; set; }

    [Display(Name = "Ontoplist Url")]
    public string OntoplistUrl { get; set; }

    [Display(Name = "Your Add to Yahoo Url. e.g. https://yourdomain/rss")]
    public string YahooUrl { get; set; }

    [Display(Name = "Bloglovin Url")]
    public string BloglovinUrl { get; set; }
    [JsonIgnore]
    public static AdvancedSettings DefaultValue => new();
}
