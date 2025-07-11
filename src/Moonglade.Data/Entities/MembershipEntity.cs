#nullable disable

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("Table for Memberships")]
public class MembershipEntity
{

  [System.ComponentModel.Description("Is the membership active?")]
  public bool Active { get; set; }

  public int Id { get; set; }

  [System.ComponentModel.Description("The language of the membership")]
  public Language Language { get; set; }

  [System.ComponentModel.Description("The link to the membership. Max length 100")]
  public string Link { get; set; }

  [System.ComponentModel.Description("The name of the membership. Max length 150")]
  public string Organization { get; set; }

  [System.ComponentModel.Description("The summary of the membership. Max length 200")]
  public string Summary { get; set; }
}
