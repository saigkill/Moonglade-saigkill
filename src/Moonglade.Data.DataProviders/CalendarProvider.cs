using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;

namespace Moonglade.Data.DataProviders
{
    /// <summary>
    /// Provider for Calendar data source.
    /// </summary>
    /// <seealso cref="CalendarEntry" />
    public class CalendarProvider : DataProvider<CalendarEntry>
    {

        private static ILogger<CalendarProvider> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarProvider"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="logger">The logger.</param>
        public CalendarProvider(IHostEnvironment env, ILogger<CalendarProvider> logger)
          : base(env, "calendar.json")
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the calendar items.
        /// </summary>
        /// <returns>List of CalendarEntries.</returns>
        public override IEnumerable<CalendarEntry> Get()
        {
            var calendar = base.Get().OrderBy(a => a.EventDate).ToList();

            return calendar;
        }
    }
}
