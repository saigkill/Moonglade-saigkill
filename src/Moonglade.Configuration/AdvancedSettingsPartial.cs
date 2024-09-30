using System.ComponentModel.DataAnnotations;

namespace Moonglade.Configuration;

public partial class AdvancedSettings : IBlogSettings
{
  [Display(Name = "Enable Syndication")]
  public bool EnableSyndication { get; set; } = true;

  [Display(Name = "Your Netvibes Url")]
  public string NetvibesUrl { get; set; }

  [Display(Name = "Your Blogarama Url")]
  public string BlogaramaUrl { get; set; }

  [Display(Name = "BlogaramaID")]
  public string BlogaramaID { get; set; }

  [Display(Name = "Enable Bloggerei")]
  public bool BloggereiEnabled { get; set; }

  [Display(Name = "Enable Bloggingfusion")]
  public bool BloggingfusionEnabled { get; set; }

  [Display(Name = "Enable Bloggeramt")]
  public bool BloggeramtEnabled { get; set; }

  [Display(Name = "Enable Topblogs")]
  public bool TopblogsEnabled { get; set; }

  [Display(Name = "Topblogs TrackerID")]
  public string TopblogsTrackerID { get; set; }

  [Display(Name = "Ontoplist Url")]
  public string OntoplistUrl { get; set; }

  [Display(Name = "Ontoplist ID")]
  public string OntoplistID { get; set; }

  [Display(Name = "Your Add to Yahoo Url. e.g. https://yourdomain/rss")]
  public string YahooUrl { get; set; }

  [Display(Name = "Bloglovin Url")]
  public string BloglovinUrl { get; set; }
}
