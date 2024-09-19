#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Data.Entities
{
  [System.ComponentModel.Description("Table of my held talks")]
  public class TalkEntity
  {
	[Description("Date and Time of the talk.")]
	public DateTime Date { get; set; }

	[Required]
	public int Id { get; set; }

	[Description("Language of the talk.")]
	public Language? Language { get; set; }

	[Description("Link to the talk.")]
	public string Link { get; set; }

	[Description("Link to the slides.")]
	public string Summary { get; set; }

	[Description("Type of the talk.")]
	public TalkType? TalkType { get; set; }

	[Description("Title of the talk.")]
	public string Title { get; set; }

	[Description("Where the talk was held.")]
	public string Where { get; set; }
  }
}

