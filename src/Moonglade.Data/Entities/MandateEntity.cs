#nullable disable

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("My Mandates")]
public class MandateEntity
{
  public int Id { get; set; }

  public Language Language { get; set; }

  [System.ComponentModel.Description("Link to a website, where you're holding the mandate.")]
  public string Link { get; set; }

  [System.ComponentModel.Description("Organization, where you're holding the mandate.")]
  public string Organization { get; set; }

  [System.ComponentModel.Description("Summary about your mandates.")]
  public string Summary { get; set; }

  [System.ComponentModel.Description("Active years")]
  public string Years { get; set; }
}
