#nullable disable
using System.ComponentModel;

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("Table of my Videos")]
public class VideoEntity
{

  [Description("Publishing date")]
  public DateTime? DatePublished { get; set; }

  [Description("Description of the video")]
  public string Description { get; set; }

  public int Id { get; set; }

  [Description("Language of the video")]
  public Language? Language { get; set; }

  [Description("Title of the video")]
  public string Title { get; set; }

  [Description("Video code. Mostly part of the Url")]
  public string VideoCode { get; set; }

  [Description("Video type")]
  public VideoType VideoType { get; set; }
}
