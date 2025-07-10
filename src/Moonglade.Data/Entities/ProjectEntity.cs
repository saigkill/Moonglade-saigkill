#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("Table with my Projects")]
public class ProjectEntity
{
  [Required]
  public int Id { get; set; }

  [Required]
  [Description("Date of completion")]
  [DataType(DataType.Date)]
  public DateTime Completion { get; set; }

  [Description("Language of the project")]
  [StringLength(50)]
  public Language Language { get; set; }

  [Required]
  [Description("Link to the project")]
  [StringLength(150)]
  public string ProjectLink { get; set; }

  [Required]
  [Description("Name of the project")]
  [StringLength(100)]
  public string ProjectName { get; set; }

  [Required]
  [Description("Summary of the project")]
  [StringLength(500)]
  public string ProjectSummary { get; set; }
}
