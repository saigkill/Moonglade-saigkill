#nullable disable

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("Table for my certificates")]
public class CertificateEntity
{

  [System.ComponentModel.Description("Title of the certificate. Max. Length 150")]
  public string CertificateTitle { get; set; }

  [System.ComponentModel.Description("Some details of the content. Max length 300")]
  public string Content { get; set; }

  [System.ComponentModel.Description("Identifier automatic Increased.")]
  public int Id { get; set; }

  [System.ComponentModel.Description("Link to a Image from the certificate. Max. 300")]
  public string Image { get; set; }

  [System.ComponentModel.Description("Is it Landscape? This entry is used for formatting the image")]
  public bool Landscape { get; set; }

  [System.ComponentModel.Description("Defined Language")]
  public Language? Language { get; set; }

  [System.ComponentModel.Description("Link to the certificate if available. Max length 300")]
  public string Link { get; set; }

  [System.ComponentModel.Description("The issuer of the certificate. Max length 150")]
  public string Provider { get; set; }

  [System.ComponentModel.Description("Year of issueing")]
  public string Year { get; set; }
}
