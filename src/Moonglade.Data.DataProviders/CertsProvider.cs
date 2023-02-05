using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moonglade.Data.DataProviders.Models;
using Moonglade.Utils;

namespace Moonglade.Data.DataProviders
{
    /// <summary>
    /// Job Certification Provider.
    /// </summary>
    /// <seealso cref="Cert" />
    public class CertsProvider : DataProvider<Cert>
    {
        private ILogger<CertsProvider> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertsProvider"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="validator">The validator.</param>
        public CertsProvider(IHostEnvironment env, ILogger<CertsProvider> logger)
            : base(env, "certificates.json")
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the certificates.
        /// </summary>
        /// <returns>Certificates List.</returns>
        public override IEnumerable<Cert> Get()
        {
            LanguageEnum culture = Helper.GetLanguage();
            var results = base.Get().Where(t => t.Language == culture).OrderByDescending(p => p.Years).ToList();

            return results;
        }
    }
}
