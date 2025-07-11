#nullable disable

using System.ComponentModel;

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("My Publications")]
public class PublicationEntity
{
  [Description("Authors of the publication")]
  public string Authors { get; set; }

  [Description("Date of publication")]
  public DateTime DatePublished { get; set; }

  [Description("Unique identifier of the publication")]
  public int Id { get; set; }

  [Description("Unique identifier of the publication")]
  public string Identifier { get; set; }

  [Description("Is this a book?")]
  public bool IsBook { get; set; }

  [Description("Language of the publication")]
  public Language? Language { get; set; }

  [Description("Link to the publication")]
  public string Link { get; set; }

  [Description("Name of the publication")]
  public string PublicationName { get; set; }

  [Description("Publisher of the publication")]
  public string Publisher { get; set; }

  [Description("Title of the publication")]
  public string Title { get; set; }

}
