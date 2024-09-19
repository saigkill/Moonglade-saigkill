#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Data.Entities
{
  [System.ComponentModel.Description("Table with my Projects")]
  public class ProjectEntity
  {

	[Description("Authors of the project. Max. length 50")]
	public string Authors { get; set; }

	[Description("Client of the project. Max. length 50")]
	public string Client { get; set; }

	[Description("Date of completion")]
	public DateTime Completion { get; set; }

	[Required]
	public int Id { get; set; }

	[Description("Language of the project")]
	public Language Language { get; set; }

	[Description("Link to the portfolio")]
	public string PortfolioLink { get; set; }

	[Description("Link to the project")]
	public string ProjectLink { get; set; }

	[Description("Name of the project")]
	public string ProjectName { get; set; }

	[Description("Summary of the project")]
	public string ProjectSummary { get; set; }

	[Description("Type of the project")]
	public string ProjectType { get; set; }
  }
}

