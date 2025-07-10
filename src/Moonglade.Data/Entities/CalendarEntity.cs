#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Data.Entities;

[System.ComponentModel.Description("My calendar of public dates")]
public class CalendarEntity
{
  [System.ComponentModel.Description("Date of Events")]
  public DateTime EventDate { get; set; }

  [System.ComponentModel.Description("Date of Events Finished")]
  public DateTime EventDateFinished { get; set; }

  [System.ComponentModel.Description("Enddate of Event.")]
  public string EventName { get; set; }

  [System.ComponentModel.Description("Unique identifier")]
  public long Id { get; set; }

  [System.ComponentModel.Description("Link to event.")]
  public string? Link { get; set; }

  [System.ComponentModel.Description("Event location.")]
  public string Location { get; set; }

  [MaxLength(150)]
  [StringLength(150)]
  [System.ComponentModel.Description("Event logo.")]
  public string Logo { get; set; }
}
