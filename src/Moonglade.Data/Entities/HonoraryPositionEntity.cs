#nullable disable

namespace Moonglade.Data.Entities
{
  [System.ComponentModel.Description("Table for our Honorary Positions")]
  public class HonoraryPositionEntity
  {

	[System.ComponentModel.Description("Is it active?")]
	public bool Active { get; set; }

	[System.ComponentModel.Description("Identification Automatically increased")]
	public int Id { get; set; }

	[System.ComponentModel.Description("The language")]
	public Language? Language { get; set; }

	[System.ComponentModel.Description("Link to the website what contains the honorary position. Max length 150")]
	public string? Link { get; set; }

	[System.ComponentModel.Description("The Organization where you have that position. Max length 100")]
	public string Organization { get; set; }

	[System.ComponentModel.Description("Summary of the work there. Max 200")]
	public string? Summary { get; set; }
  }
}
