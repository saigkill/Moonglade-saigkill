using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
    public class PublicationProvider : DataProvider<Publications>
    {
        private ILogger<PublicationProvider> _logger;
        private IHostEnvironment _env;

        public PublicationProvider(IHostEnvironment env, ILogger<PublicationProvider> logger) : base(env, "publications.json")
        {
            _logger = logger;
            _env = env;
        }

        public override IEnumerable<Publications> Get()
        {
            LanguageEnum culture = Helper.GetLanguage();
            var publications = base.Get().OrderByDescending(p => p.DatePublished).Where(p => p.Language == culture).ToList();
            return publications;
        }
    }
}
