using System.ComponentModel.DataAnnotations;

namespace Moonglade.Data.DataProviders.Models
{
    /// <summary>
    /// Calender Entry class.
    /// </summary>
    public class CalendarEntry
    {
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        [Required]
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        [Required]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        [Required]
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [Required]
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public string Logo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether [reverse logo].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [reverse logo]; otherwise, <c>false</c>.
        /// </value>
        public bool ReverseLogo { get; set; } = false;

        /// <summary>
        /// Gets the formatted date.
        /// </summary>
        /// <value>
        /// The formatted date.
        /// </value>
        public string FormattedDate
        {
            get
            {
                if (Length > 1)
                {
                    var endDate = EventDate.AddDays(Length - 1);
                    if (endDate.Month == EventDate.Month)
                    {
                        return $"{EventDate:MMM} {EventDate.Day}-{endDate.Day}, {EventDate.Year}";
                    }
                    else
                    {
                        if (endDate.Year == EventDate.Year)
                        {
                            return string.Format("{0:MMM} {2}-{1:MMM} {3}, {4}", EventDate, endDate, EventDate.Day, endDate.Day, EventDate.Year);
                        }
                        else
                        {
                            return $"{EventDate:MMM d, YYYY}-{endDate:MMM d, YYYY}";
                        }
                    }
                }
                else
                {
                    return EventDate.ToString("MMM d, yyyy");
                }
            }
        }
    }
}
